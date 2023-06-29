using AutoMapper;

namespace AutomatedWorkplaceCarService.BLL.Infrastructure.Mapping
{
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg => {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<BrandMappingProfile>();
                cfg.AddProfile<ModelMappingProfile>();
                cfg.AddProfile<TransmissionMappingProfile>();
                cfg.AddProfile<CarMappingProfile>();
                cfg.AddProfile<ImageMappingProfile>();
                cfg.AddProfile<ClientMappingProfile>();
                cfg.AddProfile<ApplicationMappingProfile>();
                cfg.AddProfile<RoleMappingProfile>();
                cfg.AddProfile<EmployeeMappingProfile>();
                cfg.AddProfile<PostMappingProfile>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
}
