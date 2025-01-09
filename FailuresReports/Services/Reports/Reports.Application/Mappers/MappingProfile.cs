using AutoMapper;
using Reports.Application.Dtos;
using Reports.Core.Common;
using Reports.Core.Entities;

namespace Reports.Application.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<FailureRegistrationSYSFT,FailureRegistrationSYSFTDto>().ReverseMap();
        CreateMap<FailureRegistrationSYSVF,FailureRegistrationSYSVFDto>().ReverseMap();
        CreateMap<PendingValidation, PendingValidationDto>().ReverseMap();
        CreateMap<ToMrb, ToMrbDto>().ReverseMap();
        CreateMap<BaseEntity, BaseDto>().ReverseMap();        
    }

}
