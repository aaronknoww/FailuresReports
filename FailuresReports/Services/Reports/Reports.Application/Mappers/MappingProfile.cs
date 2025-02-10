using AutoMapper;
using Reports.Application.Dtos;
using Reports.Core.Common;
using Reports.Core.Entities;

namespace Reports.Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<FailureRegistrationSYSFTEntity,FailureRegistrationSYSFTDto>().ReverseMap();
        CreateMap<FailureRegistrationSYSVFEntity,FailureRegistrationSYSVFDto>().ReverseMap();
        CreateMap<PendingValidationEntity, PendingValidationDto>().ReverseMap();
        CreateMap<ToMrbEntity, ToMrbDto>().ReverseMap();
        CreateMap<BaseEntity, BaseDto>().ReverseMap();        
    }

}
