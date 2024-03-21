using AutoGlass.ProductManagement.Application.DTOs.Product;
using AutoGlass.ProductManagement.Application.DTOs.Product.Response;
using AutoGlass.ProductManagement.Application.Interfaces.Product;
using AutoGlass.ProductManagement.Domain.Entities;
using AutoGlass.ProductManagement.Domain.Interfaces.Services;
using AutoMapper;
using FluentValidation;

namespace AutoGlass.ProductManagement.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        public ProductAppService(IProductService productService, IMapper mapper, IValidator<CreateProductDto> validator, IValidator<ProductDto> validatorEditProduct)
        {
            _productService = productService;
            _mapper = mapper;
            _validatorCreateProduct = validator;
            _validatorEditProduct = validatorEditProduct;
        }

        public CreateProductResponseDto CreateProduct(CreateProductDto createProductDto)
        {
            var validationResult = _validatorCreateProduct.Validate(createProductDto);

            if (validationResult.IsValid)
            {
                var productMap = MapCreateProductDtoToProduct(createProductDto);
                int productId = _productService.Insert(productMap);

                return new CreateProductResponseDto { ProductId = productId };
            }

            return new CreateProductResponseDto { ProductId = 0, Errors = validationResult.Errors };
        }

        private Product MapCreateProductDtoToProduct(CreateProductDto createProductDto) => _mapper.Map<Product>(createProductDto);

        public ProductDto GetById(int id)
        {
            var product = _productService.GetById(id);
            var productDtoMap = MapProductDtoToProduct(product);

            return productDtoMap;
        }

        private ProductDto MapProductDtoToProduct(Product product) => _mapper.Map<ProductDto>(product);

        public EditProductResponseDto Update(ProductDto productDto)
        {
            var validationResult = _validatorEditProduct.Validate(productDto);

            if (!validationResult.IsValid)
                return new EditProductResponseDto { IsSuccess = false, Errors = validationResult.Errors };

            var product = _productService.GetById(productDto.Id);
            var productMap = _mapper.Map(productDto, product);

            var isSucess = _productService.Update(productMap);

            return new EditProductResponseDto { IsSuccess = isSucess };
        }

        public bool Delete(int id)
        {
            var product = _productService.GetById(id);
            product.Status = false;

            var isSucess = _productService.Update(product);

            return isSucess;
        }

        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateProductDto> _validatorCreateProduct;
        private readonly IValidator<ProductDto> _validatorEditProduct;
    }
}
