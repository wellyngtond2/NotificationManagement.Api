using System.Collections.Generic;
using System.Threading.Tasks;
using NotificationManagement.Domain.Domain.Models;
using NotificationManagement.Domain.Dtos;

namespace NotificationManagement.Domain.Domain.Interfaces.Repository
{
    public interface INotificationRepository : IRepositoryBase<Notification>
    {
        Task<ICollection<Notification>> GetAllIncludeEntitiesAsync(int? recordsPerPage, int? pageNumber);
        Task<ICollection<Notification>> GetUnSentAsync();
        Task SetAsSentAsync(Notification notification);
        Task<NotificationTotalsDto> GetTotalsAsync();
    }
}
