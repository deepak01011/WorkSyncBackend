using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WorkSync.Infra.Data.Context;

public class EventStoreContextFactory : IDesignTimeDbContextFactory<EventStoreSqlContext>
{
    public EventStoreSqlContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddUserSecrets<EventStoreContextFactory>(optional: true)
            .Build();

        var builder = new DbContextOptionsBuilder<EventStoreSqlContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        builder.UseSqlServer(connectionString);

        return new EventStoreSqlContext(builder.Options);
    }
}
