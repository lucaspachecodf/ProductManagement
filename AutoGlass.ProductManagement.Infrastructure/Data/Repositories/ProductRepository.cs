using AutoGlass.ProductManagement.Context;
using AutoGlass.ProductManagement.Domain.Entities;
using AutoGlass.ProductManagement.Domain.Interfaces.Repositories;

namespace AutoGlass.ProductManagement.Infrastructure.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product, int>, IProductRepository
    {
        public ProductRepository(ProductManagementDataContext context) : base(context)
        {

        }
    }
}
