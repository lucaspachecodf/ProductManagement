using AutoGlass.ProductManagement.Application.DTOs.Product;
using AutoGlass.ProductManagement.Application.DTOs.Product.Response;

namespace AutoGlass.ProductManagement.Application.Interfaces.Product
{
    public interface IProductAppService
    {
        CreateProductResponseDto CreateProduct(CreateProductDto createProductDto);
        ProductDto GetById(int id);
        EditProductResponseDto Update(ProductDto productDto);
        bool Delete(int id);        
    }
}
