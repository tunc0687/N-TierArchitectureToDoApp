using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArchitectureToDoApp.DataDomain.EfCoreRepository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, new()
    {
        private readonly DbContext _context;
        public readonly DbSet<TEntity> _collection;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _collection = _context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _collection.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _collection.Remove(entity);
        }

        public void DeleteAll(IEnumerable<TEntity> entities)
        {
            _collection.RemoveRange(entities);
        }

        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _collection.SingleOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _collection.ToListAsync();
        }

        public void Update(TEntity entity)
        {
            _collection.Update(entity);
        }
    }
}
