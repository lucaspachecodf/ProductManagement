using AutoGlass.ProductManagement.Application.DTOs.Product;
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

                cfg.CreateMap<Product, ProductDto>();
                cfg.CreateMap<ProductDto, Product>();
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
