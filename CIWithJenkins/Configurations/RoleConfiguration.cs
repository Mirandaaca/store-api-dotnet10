using CIWithJenkins.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIWithJenkins.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles");

            builder.HasKey(role => role.Id);

            builder.Property(role => role.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(role => role.Description)
                .HasMaxLength(250)
                .IsRequired();
        }
    }
}
