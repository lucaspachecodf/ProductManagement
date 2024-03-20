using AutoGlass.ProductManagement.Application.DTOs;
using AutoGlass.ProductManagement.Application.Interfaces;
using AutoGlass.ProductManagement.Domain.Entities;
using AutoGlass.ProductManagement.Domain.Interfaces.Services;
using AutoMapper;
using FluentValidation;

namespace AutoGlass.ProductManagement.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        public ProductAppService(IProductService productService, IMapper mapper, IValidator<CreateProductDto> validator)
        {
            _productService = productService;
            _mapper = mapper;
            _validator = validator;
        }

        public CreateProductResponseDto CreateProduct(CreateProductDto createProductDto)
        {
            var validationResult = _validator.Validate(createProductDto);

            if (!validationResult.IsValid)            
                return new CreateProductResponseDto { ProductId = 0, Errors = validationResult.Errors };

            var product = MapCreateProductDtoToProduct(createProductDto);
            int productId = _productService.Insert(product);

            return new CreateProductResponseDto { ProductId = productId };
        }

        private Product MapCreateProductDtoToProduct(CreateProductDto createProductDto)
        {
            return _mapper.Map<Product>(createProductDto);
        }

        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateProductDto> _validator;
    }
}
