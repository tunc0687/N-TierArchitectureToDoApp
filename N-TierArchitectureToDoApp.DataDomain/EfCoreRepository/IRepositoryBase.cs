using N_TierArchitectureToDoApp.DataDomain.Entities;
using System.Linq.Expressions;

namespace N_TierArchitectureToDoApp.DataDomain.EfCoreRepository
{
    public interface IRepositoryBase<T> where T : BaseEntity, new()
    {
        Task AddAsync(T entity);
        void Update(T entity, T unchangedEntity);
        void Delete(T entity);
        void DeleteAll(IEnumerable<T> entities);
        Task<IList<T>> GetAllAsync();
        Task<T?> FindAsync(Expression<Func<T, bool>> expression);
    }
}
