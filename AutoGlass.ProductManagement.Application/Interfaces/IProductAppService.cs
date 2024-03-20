using AutoGlass.ProductManagement.Application.DTOs;

namespace AutoGlass.ProductManagement.Application.Interfaces
{
    public interface IProductAppService
    {
        CreateProductResponseDto CreateProduct(CreateProductDto createProductDto);
    }
}
