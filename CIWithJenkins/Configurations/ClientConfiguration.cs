using CIWithJenkins.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIWithJenkins.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");

            builder.HasKey(client => client.Id);

            builder.Property(client => client.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(client => client.Surname)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(client => client.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(client => client.Phone)
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
