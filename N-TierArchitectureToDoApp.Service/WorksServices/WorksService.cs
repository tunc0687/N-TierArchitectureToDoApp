using AutoMapper;
using FluentValidation;
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
        private readonly IValidator<WorksUpdateRequest> _worksUpdateValidator;
        private readonly IValidator<WorksAddRequest> _worksAddValidator;

        public WorksService(IWorksRepository worksRepository, IUnitOfWork unitOfWork, IMapper mapper, IValidator<WorksUpdateRequest> worksUpdateValidator, IValidator<WorksAddRequest> worksAddValidator)
        {
            _worksRepository = worksRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _worksUpdateValidator = worksUpdateValidator;
            _worksAddValidator = worksAddValidator;
        }

        public async Task Add(WorksAddRequest request)
        {
            var validation = await _worksAddValidator.ValidateAsync(request);
            if (validation.IsValid)
            {
                await _worksRepository.AddAsync(_mapper.Map<Work>(request));
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteById(int id)
        {
            var entity = await _worksRepository.FindAsync(w => w.Id == id);
            if (entity != null)
            {
                _worksRepository.Delete(entity);

                await _unitOfWork.SaveChangesAsync();
            }
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
            var validation = await _worksUpdateValidator.ValidateAsync(request);
            if (validation.IsValid)
            {
                var unchangedEntity = await _worksRepository.FindAsync(w => w.Id == request.Id);

                if (unchangedEntity != null)
                {
                    var entity = _mapper.Map<Work>(request);

                    _worksRepository.Update(entity, unchangedEntity);

                    await _unitOfWork.SaveChangesAsync();
                }
            }
        }
    }
}
