using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PocketBank.User.DataAccess.Common.Entities;

namespace PocketBank.User.DataAccess.Common.Configurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.MiddleName)
                .HasMaxLength(50);

            builder.Property(c => c.PassportNumber)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.Email)
                .HasMaxLength(255)
                .IsRequired();
            builder.HasIndex(c => c.Email)
                .IsUnique();

            builder.Property(c => c.Password)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
