using AutoGlass.ProductManagement.Domain.Entities;
using AutoGlass.ProductManagement.Domain.Interfaces.Repositories;
using AutoGlass.ProductManagement.Domain.Interfaces.Services;

namespace AutoGlass.ProductManagement.Domain.Services
{
    public class ProductService : ServiceBase<Product, int>, IProductService
    {
        public ProductService(IRepositoryBase<Product, int> repository) : base(repository)
        {

        }
    }
}
