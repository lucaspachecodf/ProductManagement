using AutoGlass.ProductManagement.Context.Interfaces;
using AutoGlass.ProductManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoGlass.ProductManagement.Context.Configuration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>, IConfigurationContext
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product")
             .HasKey(key => new { key.Id });

            builder.Property(p => p.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnName("Description")
                .IsRequired();

            builder.Property(p => p.Status)
                .HasColumnName("Status")
                .HasColumnType("bit");

            builder.Property(p => p.ManufacturingDate)
                .HasColumnName("ManufacturingDate")
                .HasColumnType("datetime");

            builder.Property(p => p.ExpirationDate)
                .HasColumnName("ExpirationDate")
                .HasColumnType("datetime");

            builder.Property(p => p.SupplierCode).HasColumnName("SupplierCode");
            builder.Property(p => p.SupplierDescription).HasColumnName("SupplierDescription");
            builder.Property(p => p.SupplierCNPJ).HasColumnName("SupplierCNPJ");
        }
    }
}
