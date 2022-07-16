using N_TierArchitectureToDoApp.Service.WorksServices.Dtos.RequestDtos;
using N_TierArchitectureToDoApp.Service.WorksServices.Dtos.ResultDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArchitectureToDoApp.Service.WorksServices
{
    public interface IWorksService
    {
        Task Add(WorksAddRequest request);
        Task UpdateById(WorksUpdateByIdRequest request);
        Task DeleteById(int id);
        Task<WorksGetByIdResult> GetById(int id);
        Task<List<WorksListResult>> GetAll();
    }
}
