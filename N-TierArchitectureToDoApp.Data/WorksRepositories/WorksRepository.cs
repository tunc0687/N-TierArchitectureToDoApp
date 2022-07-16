using N_TierArchitectureToDoApp.DataDomain.DbContexts;
using N_TierArchitectureToDoApp.DataDomain.EfCoreRepository;
using N_TierArchitectureToDoApp.DataDomain.Entities;

namespace N_TierArchitectureToDoApp.Data.WorksRepositories
{
    public class WorksRepository : RepositoryBase<Work>, IWorksRepository
    {
        public WorksRepository(ToDoAppDbContext context) : base(context)
        {
        }
    }
}
