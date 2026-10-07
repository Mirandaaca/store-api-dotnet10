using CIWithJenkins.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIWithJenkins.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");

            builder.HasKey(sale => sale.Id);

            builder.Property(sale => sale.Date)
                .IsRequired();

            // Calculated on the server as the sum of its sale details, never sent by the client
            builder.Property(sale => sale.Total)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(sale => sale.PaymentMethod)
                .IsRequired();

            builder.HasOne(sale => sale.User)
                .WithMany(user => user.Sales)
                .HasForeignKey(sale => sale.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sale => sale.Client)
                .WithMany(client => client.Sales)
                .HasForeignKey(sale => sale.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(sale => sale.Date);
        }
    }
}
