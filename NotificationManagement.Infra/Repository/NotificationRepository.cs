using Microsoft.EntityFrameworkCore;
using NotificationManagement.Domain.Domain.Interfaces.Repository;
using NotificationManagement.Domain.Domain.Models;
using NotificationManagement.Infra.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotificationManagement.Domain.Dtos;

namespace NotificationManagement.Infra.Repository
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(NotificationDbContext dbContext) : base(dbContext) { }
        public async Task<ICollection<Notification>> GetAllIncludeEntitiesAsync(int? recordsPerPage, int? pageNumber)
        {
            var skipRegisters = ((pageNumber ?? 1) - 1) * (recordsPerPage ?? 10);

            return await _dbContext.Notifications
                         .Include(c => c.Person)
                         .Include(c => c.NotificationTemplate)
                         .Skip(skipRegisters)
                         .Take(recordsPerPage ?? 10)
                         .ToListAsync();
        }

        public async Task<ICollection<Notification>> GetUnSentAsync()
        {
            return await _dbContext.Notifications
                .Include(c => c.NotificationTemplate)
                .Where(c => c.WasSent == false)
                .ToListAsync();
        }

        public async Task SetAsSentAsync(Notification notification)
        {
            notification.WasSent = true;
            _dbContext.Attach(notification).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<NotificationTotalsDto> GetTotalsAsync()
        {
            return new NotificationTotalsDto()
            {
                Total = await _dbContext.Notifications.Select(c => c.Id).CountAsync(),
                UnSentTotal = await _dbContext.Notifications.Where(c => !c.WasSent).Select(c => c.Id).CountAsync(),
            };
        }
    }
}