using AutoMapper;
using SuperHeroAPI_DotNet8.Entities;
using SuperHeroAPI_DotNet8.Entities.DTOs;

namespace SuperHeroAPI_DotNet8.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Agency, AgencyUpdateDto>();
        CreateMap<AgencyAddDto, Agency>();
        CreateMap<Agency, AgencyAddDto>();
    }
}