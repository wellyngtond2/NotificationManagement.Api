using Microsoft.EntityFrameworkCore;
using NotificationManagement.Domain.Domain.Interfaces.Repository;
using NotificationManagement.Domain.Domain.Models;
using NotificationManagement.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NotificationManagement.Infra.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        protected readonly NotificationDbContext _dbContext;

        public RepositoryBase(NotificationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Attach<T>(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await _dbContext.Set<T>().Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Attach<T>(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ICollection<T>> GetAllAsync(int? recordsPerPage, int? pageNumber)
        {
            if (recordsPerPage != null && pageNumber != null)
            {
                return await _dbContext.Set<T>().Skip((pageNumber.Value - 1) * recordsPerPage.Value)
                    .Take(recordsPerPage.Value).ToListAsync();
            }

            return await _dbContext.Set<T>().ToListAsync();
        }
    }
}