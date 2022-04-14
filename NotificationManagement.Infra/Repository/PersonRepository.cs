using NotificationManagement.Domain.Domain.Interfaces.Repository;
using NotificationManagement.Domain.Domain.Models;
using NotificationManagement.Infra.Data;

namespace NotificationManagement.Infra.Repository
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(NotificationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
