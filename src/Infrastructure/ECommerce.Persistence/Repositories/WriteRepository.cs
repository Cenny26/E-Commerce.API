using ECommerce.Application.Interfaces.Repositories;
using ECommerce.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext _dbContext;
        public WriteRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<T> _Table { get => _dbContext.Set<T>(); }

        public async Task AddAsync(T entity)
        {
            await _Table.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await _Table.AddRangeAsync(entities);
        }

        public async Task HardDeleteAsync(T entity)
        {
            await Task.Run(() => _Table.Remove(entity));
        }

        public async Task<T> UpdateAsync(T entity)
        {
            await Task.Run(() => _Table.Update(entity));
            return entity;
        }
    }
}
