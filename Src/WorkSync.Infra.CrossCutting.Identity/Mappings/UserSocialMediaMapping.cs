using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WorkSync.Infra.CrossCutting.Identity.Models;

namespace WorkSync.Infra.CrossCutting.Identity.Mappings;

public class UserSocialMediaMapping : IEntityTypeConfiguration<UserSocialMedia>
{
    public void Configure(EntityTypeBuilder<UserSocialMedia> builder)
    {
        builder.Property(u => u.Facebook)
            .HasColumnType("varchar(500)")
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(u => u.Twitter)
            .HasColumnType("varchar(500)")
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(u => u.Instagram)
            .HasColumnType("varchar(500)")
            .HasMaxLength(500)
            .IsRequired(false);

        builder.Property(u => u.LinkedIn)
            .HasColumnType("varchar(500)")
            .HasMaxLength(500)
            .IsRequired(false);
    }
}
