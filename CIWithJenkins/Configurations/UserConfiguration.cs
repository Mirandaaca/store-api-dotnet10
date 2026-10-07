using CIWithJenkins.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CIWithJenkins.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Username)
                .HasMaxLength(100)
                .IsRequired();

            // Sized to hold a hash, never a plain text password
            builder.Property(user => user.Password)
                .HasMaxLength(255)
                .IsRequired();

            builder.HasIndex(user => user.Username)
                .IsUnique();

            builder.HasOne(user => user.Role)
                .WithMany(role => role.Users)
                .HasForeignKey(user => user.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
