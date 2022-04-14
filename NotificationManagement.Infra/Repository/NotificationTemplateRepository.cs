using NotificationManagement.Domain.Domain.Interfaces.Repository;
using NotificationManagement.Domain.Domain.Models;
using NotificationManagement.Infra.Data;

namespace NotificationManagement.Infra.Repository
{
    public class NotificationTemplateRepository : RepositoryBase<NotificationTemplate>, INotificationTemplateRepository
    {
        public NotificationTemplateRepository(NotificationDbContext dbContext) : base(dbContext) { }
    }
}
