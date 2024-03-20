using AutoGlass.ProductManagement.Application.DTOs;
using AutoGlass.ProductManagement.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AutoGlass.ProductManagement.IoC.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void ConfigureMappings(IServiceCollection services)
        {            
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, CreateProductDto>();
                cfg.CreateMap<CreateProductDto, Product>();                                                      
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
