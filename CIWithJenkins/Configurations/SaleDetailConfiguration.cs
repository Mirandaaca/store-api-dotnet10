using CIWithJenkins.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIWithJenkins.Configurations
{
    public class SaleDetailConfiguration : IEntityTypeConfiguration<SaleDetail>
    {
        public void Configure(EntityTypeBuilder<SaleDetail> builder)
        {
            builder.ToTable("SaleDetails");

            builder.HasKey(saleDetail => saleDetail.Id);

            // Units of the product sold in this sale
            builder.Property(saleDetail => saleDetail.Quantity)
                .IsRequired();

            // Historical snapshot of Product.Price at the moment of the sale, so that
            // later price changes do not rewrite past reports
            builder.Property(saleDetail => saleDetail.UnitPrice)
                .HasPrecision(18, 2)
                .IsRequired();

            // Maintained by PostgreSQL as a stored generated column: it cannot fall out of
            // sync with UnitPrice and Quantity, and assigning it from C# has no effect
            builder.Property(saleDetail => saleDetail.Subtotal)
                .HasPrecision(18, 2)
                .HasComputedColumnSql("\"UnitPrice\" * \"Quantity\"", stored: true);

            // Deleting a sale deletes its lines: a detail has no meaning without its sale
            builder.HasOne(saleDetail => saleDetail.Sale)
                .WithMany(sale => sale.SaleDetails)
                .HasForeignKey(saleDetail => saleDetail.SaleId)
                .OnDelete(DeleteBehavior.Cascade);

            // A product that has already been sold cannot be deleted: it would erase sales history
            builder.HasOne(saleDetail => saleDetail.Product)
                .WithMany(product => product.SaleDetails)
                .HasForeignKey(saleDetail => saleDetail.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // One line per product within a sale: a repeated product must be consolidated into Quantity
            builder.HasIndex(saleDetail => new { saleDetail.SaleId, saleDetail.ProductId })
                .IsUnique();
        }
    }
}
