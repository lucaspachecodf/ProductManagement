using AutoGlass.ProductManagement.Application.DTOs.Product;
using AutoGlass.ProductManagement.Application.Interfaces.Product;
using AutoGlass.ProductManagement.Application.Models;
using AutoGlass.ProductManagement.Domain.Entities;
using AutoGlass.ProductManagement.Domain.Interfaces.Services;
using AutoMapper;

namespace AutoGlass.ProductManagement.Application.Services
{
    public class ProductFilterAppService : IProductFilterAppService
    {
        public ProductFilterAppService(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public PaginatedResult<ProductDto> GetFilteredProducts(ProductFilterDto filter)
        {
            var query = _productService.FindByProperty(
                    p =>
                    DescriptionMatchesFilter(p, filter) ||
                    StatusMatchesFilter(p, filter) ||
                    ManufacturingDateMatchesFilter(p, filter) ||
                    ExpirationDateMatchesFilter(p, filter) ||
                    SupplierCodeMatchesFilter(p, filter) ||
                    SupplierCNPJMatchesFilter(p, filter)
                );

            int totalItems = query.Count();
            int skip = (filter.PageNumber - 1) * filter.PageSize;
            query = query.Skip(skip).Take(filter.PageSize);

            var productDtoMap = _mapper.Map<IEnumerable<ProductDto>>(query);

            return new PaginatedResult<ProductDto>(productDtoMap, totalItems, filter.PageNumber, filter.PageSize);
        }

        private bool DescriptionMatchesFilter(Product product, ProductFilterDto filter)
        {
            return !string.IsNullOrEmpty(filter.Description) && product.Description.Contains(filter.Description);
        }

        private bool StatusMatchesFilter(Product product, ProductFilterDto filter)
        {
            return product.Status == filter.Status;
        }

        private bool ManufacturingDateMatchesFilter(Product product, ProductFilterDto filter)
        {
            return filter.ManufacturingDate.HasValue && product.ManufacturingDate.Date == filter.ManufacturingDate.Value.Date;
        }

        private bool ExpirationDateMatchesFilter(Product product, ProductFilterDto filter)
        {
            return filter.ExpirationDate.HasValue && product.ExpirationDate.Date == filter.ExpirationDate.Value.Date;
        }

        private bool SupplierCodeMatchesFilter(Product product, ProductFilterDto filter)
        {
            return !string.IsNullOrEmpty(filter.SupplierCode) && product.SupplierCode.Contains(filter.SupplierCode);
        }

        private bool SupplierCNPJMatchesFilter(Product product, ProductFilterDto filter)
        {
            return !string.IsNullOrEmpty(filter.SupplierCNPJ) && product.SupplierCNPJ.Contains(filter.SupplierCNPJ);
        }

        private readonly IProductService _productService;
        private readonly IMapper _mapper;
    }
}
