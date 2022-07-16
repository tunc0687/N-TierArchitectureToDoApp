using N_TierArchitectureToDoApp.Data.WorksRepositories;
using N_TierArchitectureToDoApp.DataDomain.EfCoreUnitOfWork;
using N_TierArchitectureToDoApp.DataDomain.Entities;
using N_TierArchitectureToDoApp.Service.WorksServices.Dtos.RequestDtos;
using N_TierArchitectureToDoApp.Service.WorksServices.Dtos.ResultDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_TierArchitectureToDoApp.Service.WorksServices
{
    public class WorksService : IWorksService
    {
        private readonly IWorksRepository _worksRepository;
        private readonly IUnitOfWork _unitOfWork;

        public WorksService(IWorksRepository worksRepository, IUnitOfWork unitOfWork)
        {
            _worksRepository = worksRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Add(WorksAddRequest request)
        {
            Work entity = new Work
            {
                Description = request.Description,
                IsCompleted = request.IsCompleted,
            };

            _worksRepository.Add(entity);
            var result = await _unitOfWork.SaveChangesAsync();
            return entity.Id;
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<WorksListResult>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<WorksGetByIdResult> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateById(int id, WorksUpdateByIdRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
