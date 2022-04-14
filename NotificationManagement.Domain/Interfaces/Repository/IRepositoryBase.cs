using NotificationManagement.Domain.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NotificationManagement.Domain.Domain.Interfaces.Repository
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task<T> GetByIdAsync(int Id);
        Task DeleteAsync(T entity);
        Task<ICollection<T>> GetAllAsync(int? recordsPerPage, int? pageNumber);
    }
}
