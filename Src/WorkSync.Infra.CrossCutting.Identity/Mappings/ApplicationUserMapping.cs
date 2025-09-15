using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WorkSync.Infra.CrossCutting.Identity.Models;

namespace WorkSync.Infra.CrossCutting.Identity.Mappings;

public class ApplicationUserMapping : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FirstName)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(u => u.LastName)
            .HasColumnType("varchar(100)")
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(u => u.ProfileUrl)
            .HasColumnType("nvarchar(1000)")
            .HasMaxLength(1000)
            .IsRequired(false);

        builder.Property(u => u.Phone)
            .HasColumnType("varchar(20)")
            .HasMaxLength(20)
            .IsRequired(false);
    }
}
