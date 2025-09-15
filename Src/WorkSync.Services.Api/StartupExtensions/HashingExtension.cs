using WorkSync.Domain.Providers.Hash;

namespace WorkSync.Services.Api.StartupExtensions;

public static class HashingExtension
{
    public static IServiceCollection AddCustomizedHash(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<HashingOptions>(configuration.GetSection(HashingOptions.Hashing));
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
