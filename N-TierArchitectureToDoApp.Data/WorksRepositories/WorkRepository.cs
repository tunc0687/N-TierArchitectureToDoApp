using N_TierArchitectureToDoApp.DataDomain.DbContexts;
using N_TierArchitectureToDoApp.DataDomain.EfCoreRepository;
using N_TierArchitectureToDoApp.DataDomain.Entities;

namespace N_TierArchitectureToDoApp.Data.WorksRepositories
{
    public class WorkRepository : RepositoryBase<Work>, IWorkRepository
    {
        public WorkRepository(ToDoAppDbContext context) : base(context)
        {
        }
    }
}
