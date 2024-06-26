﻿using AutoGlass.ProductManagement.Application.DTOs.Product;
using AutoGlass.ProductManagement.Application.Interfaces.Product;
using AutoGlass.ProductManagement.Application.Services;
using AutoGlass.ProductManagement.Application.Validators.Product;
using AutoGlass.ProductManagement.Context;
using AutoGlass.ProductManagement.Domain.Interfaces.Repositories;
using AutoGlass.ProductManagement.Domain.Interfaces.Services;
using AutoGlass.ProductManagement.Domain.Services;
using AutoGlass.ProductManagement.Infrastructure.Data.Repositories;
using AutoGlass.ProductManagement.IoC.AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutoGlass.ProductManagement.IoC.Inicialize
{
    public static class InicializeIoC
    {
        public static void AddDependenceInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductManagementDataContext>(options => options.UseSqlServer(configuration.GetConnectionString("ProductManagementConnection")));
            services.AddScoped(typeof(IServiceBase<,>), typeof(ServiceBase<,>));
            services.AddScoped(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));

            //AutoMapper
            AutoMapperConfig.ConfigureMappings(services);

            //Repositores
            services.AddScoped<IProductRepository, ProductRepository>();

            //Validators
            services.AddScoped<IValidator<CreateProductDto>, CreateProductValidator>();
            services.AddScoped<IValidator<ProductDto>, EditProductValidator>();

            //Services
            services.AddScoped<IProductAppService, ProductAppService>();
            services.AddScoped<IProductFilterAppService, ProductFilterAppService>();
            services.AddScoped<IProductService, ProductService>();                        
        }
    }
}
