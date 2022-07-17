using Microsoft.EntityFrameworkCore;
using N_TierArchitectureToDoApp.DataDomain.Entities;
using System.Linq.Expressions;

namespace N_TierArchitectureToDoApp.DataDomain.EfCoreRepository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly DbContext _context;
        public readonly DbSet<TEntity> _collection;

        public RepositoryBase(DbContext context)
        {
            _context = context;
            _collection = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _collection.AddAsync(entity);
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

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _collection.ToListAsync();
        }

        public void Update(TEntity entity)
        {
            //_collection.Update(entity);

            var updatedEntity = _collection.SingleOrDefault(w => w.Id == entity.Id);

            _context.Entry(updatedEntity).CurrentValues.SetValues(entity);

        }
    }
}
