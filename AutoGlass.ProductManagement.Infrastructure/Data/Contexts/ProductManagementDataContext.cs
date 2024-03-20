using AutoGlass.ProductManagement.Context.Interfaces;
using AutoGlass.ProductManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AutoGlass.ProductManagement.Context
{
    public class ProductManagementDataContext : DbContext
    {
        public ProductManagementDataContext(DbContextOptions<ProductManagementDataContext> options) : base (options)
        {                
        }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
                                  where x.IsClass && typeof(IConfigurationContext).IsAssignableFrom(x)
                                  select x).ToList();

            foreach (var mapping in typesToMapping)
            {
                dynamic mappingClass = Activator.CreateInstance(mapping);
                modelBuilder.ApplyConfiguration(mappingClass);
            }
        }
    }
}
