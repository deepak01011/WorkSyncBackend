using Microsoft.EntityFrameworkCore;
using WorkSync.Infra.CrossCutting.Identity.Data;
using WorkSync.Infra.Data.Context;

namespace WorkSync.Services.Api.StartupExtensions;

public static class DatabaseExtension
{
    public static IServiceCollection AddCustomizedDatabase(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env)
    {
        services.AddDbContext<AuthDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            // options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            if (!env.IsProduction())
            {
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            }
        });

        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            // options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            if (!env.IsProduction())
            {
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            }
        });

        services.AddDbContext<EventStoreSqlContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            // options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            if (!env.IsProduction())
            {
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            }
        });

        return services;
    }

    public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;

            var authContext = services.GetRequiredService<AuthDbContext>();
            authContext?.Database.Migrate();

            var applicationContext = services.GetRequiredService<ApplicationDbContext>();
            applicationContext?.Database.Migrate();

            var eventStoreContext = services.GetRequiredService<EventStoreSqlContext>();
            eventStoreContext?.Database.Migrate();
        }

        return app;
    }
}
