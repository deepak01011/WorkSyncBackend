using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WorkSync.Infra.CrossCutting.Identity.Models;

namespace WorkSync.Infra.CrossCutting.Identity.Mappings;

public class UserAddressMapping : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.Property(u => u.Street)
            .HasColumnType("varchar(200)")
            .HasMaxLength(200)
            .IsRequired(true);

        builder.Property(u => u.City)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired(true);

        builder.Property(u => u.State)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired(true);

        builder.Property(u => u.Country)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired(true);

        builder.Property(u => u.ZipCode)
            .HasColumnType("varchar(10)")
            .HasMaxLength(10)
            .IsRequired(true);
    }
}
