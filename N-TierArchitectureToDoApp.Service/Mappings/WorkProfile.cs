using AutoMapper;
using N_TierArchitectureToDoApp.DataDomain.Entities;
using N_TierArchitectureToDoApp.Service.WorksServices.Dtos.RequestDtos;
using N_TierArchitectureToDoApp.Service.WorksServices.Dtos.ResultDtos;

namespace N_TierArchitectureToDoApp.Service.Mappings
{
    public class WorkProfile : Profile
    {
        public WorkProfile()
        {
            CreateMap<Work, WorksAddRequest>().ReverseMap();
            CreateMap<Work, WorksListResult>().ReverseMap();
            CreateMap<Work, WorksUpdateRequest>().ReverseMap();
        }
    }
}
