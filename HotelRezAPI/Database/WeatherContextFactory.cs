using HotelRezAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

public class WeatherContextFactory : IDesignTimeDbContextFactory<WeatherContext>
{
    public WeatherContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // important
            .AddJsonFile("local.settings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString = configuration["Values:SqlConnection"];

        var optionsBuilder = new DbContextOptionsBuilder<WeatherContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new WeatherContext(optionsBuilder.Options);
    }
}
