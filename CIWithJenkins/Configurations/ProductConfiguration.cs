using CIWithJenkins.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIWithJenkins.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(product => product.Id);

            builder.Property(product => product.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(product => product.Brand)
                .HasMaxLength(100)
                .IsRequired();

            // Available stock, unrelated to SaleDetail.Quantity (units sold in a sale)
            builder.Property(product => product.Quantity)
                .IsRequired();

            // Current price of the product, which may change over time
            builder.Property(product => product.Price)
                .HasPrecision(18, 2)
                .IsRequired();
        }
    }
}
