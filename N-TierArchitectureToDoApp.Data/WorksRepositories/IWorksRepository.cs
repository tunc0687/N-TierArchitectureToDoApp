using N_TierArchitectureToDoApp.DataDomain.EfCoreRepository;
using N_TierArchitectureToDoApp.DataDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArchitectureToDoApp.Data.WorksRepositories
{
    public interface IWorksRepository : IRepositoryBase<Work>
    {
    }
}
