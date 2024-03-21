using AutoGlass.ProductManagement.Application.DTOs.Product;
using AutoGlass.ProductManagement.Application.Models;

namespace AutoGlass.ProductManagement.Application.Interfaces.Product
{
    public interface IProductFilterAppService
    {
        PaginatedResult<ProductDto> GetFilteredProducts(ProductFilterDto filter);
    }
}
