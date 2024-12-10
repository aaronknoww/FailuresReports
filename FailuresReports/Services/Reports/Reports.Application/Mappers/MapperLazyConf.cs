using AutoMapper;

namespace Reports.Application.Mappers;

public static class MapperLazyConf
{
    private static readonly Lazy<IMapper> _mapper = new Lazy<IMapper>(()=>
    {
        MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<MappingProfile>();
        });
        IMapper mapper = config.CreateMapper();
        return mapper;

    });
    public static IMapper Mapper => _mapper.Value; 

}