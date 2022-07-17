using N_TierArchitectureToDoApp.Data.WorksRepositories;
using N_TierArchitectureToDoApp.DataDomain.EfCoreUnitOfWork;
using N_TierArchitectureToDoApp.DataDomain.Entities;
using N_TierArchitectureToDoApp.Service.WorksServices.Dtos.RequestDtos;
using N_TierArchitectureToDoApp.Service.WorksServices.Dtos.ResultDtos;

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

        public async Task Add(WorksAddRequest request)
        {
            Work entity = new Work
            {
                Description = request.Description,
                IsCompleted = request.IsCompleted,
            };

            await _worksRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteById(int id)
        {
            var entity = await _worksRepository.FindAsync(w => w.Id == id);
            _worksRepository.Delete(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<WorksListResult>> GetAll()
        {
            var list = await _worksRepository.GetAllAsync();
            var workList = new List<WorksListResult>();
            if (list != null && list.Count > 0)
            {
                foreach (var work in list)
                {
                    workList.Add(new WorksListResult
                    {
                        Id = work.Id,
                        Description = work.Description,
                        IsCompleted = work.IsCompleted,
                    });
                }
            }
            return workList;
        }

        public async Task<WorksListResult> GetById(int id)
        {
            var entity = await _worksRepository.FindAsync(w => w.Id == id);
            return new WorksListResult
            {
                Id = entity.Id,
                Description = entity.Description,
                IsCompleted = entity.IsCompleted,
            };
        }

        public async Task Update(WorksUpdateRequest request)
        {
            var entity = await _worksRepository.FindAsync(w => w.Id == request.Id);

            entity.Description = request.Description;
            entity.IsCompleted = request.IsCompleted;

            _worksRepository.Update(entity);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
