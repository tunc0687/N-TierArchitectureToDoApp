using AutoMapper;
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
        private readonly IMapper _mapper;

        public WorksService(IWorksRepository worksRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _worksRepository = worksRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Add(WorksAddRequest request)
        {
            await _worksRepository.AddAsync(_mapper.Map<Work>(request));
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
            return _mapper.Map<List<WorksListResult>>(await _worksRepository.GetAllAsync());
        }

        public async Task<WorksListResult> GetById(int id)
        {
            return _mapper.Map<WorksListResult>(await _worksRepository.FindAsync(w => w.Id == id));
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
