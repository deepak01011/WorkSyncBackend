using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using WorkSync.Infra.CrossCutting.Identity.Mappings;
using WorkSync.Infra.CrossCutting.Identity.Models;

namespace WorkSync.Infra.CrossCutting.Identity.Data;

public class AuthDbContext : IdentityDbContext<ApplicationUser>
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options)
    {
    }

    public DbSet<RefreshToken> RefreshTokens { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ApplicationUserMapping());
        modelBuilder.ApplyConfiguration(new UserAddressMapping());
        modelBuilder.ApplyConfiguration(new UserSocialMediaMapping());
        base.OnModelCreating(modelBuilder);
    }
}
