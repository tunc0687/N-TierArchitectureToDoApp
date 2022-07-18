using N_TierArchitectureToDoApp.Service.WorksServices.Dtos.RequestDtos;
using N_TierArchitectureToDoApp.Service.WorksServices.Dtos.ResultDtos;

namespace N_TierArchitectureToDoApp.Service.WorksServices
{
    public interface IWorksService
    {
        Task Add(WorksAddRequest request);
        Task Update(WorksUpdateRequest request);
        Task DeleteById(int id);
        Task<WorksListResult> GetById(int id);
        Task<List<WorksListResult>> GetAll();
    }
}
