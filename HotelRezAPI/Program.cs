using HotelRezAPI.Database;
using HotelRezAPI.Repositories;
using HotelRezAPI.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddScoped<IGetWeatherService, GetWeatherService>();
        services.AddScoped<IGetWeatherRepository, GetWeatherRepository>();

        var configuration = new ConfigurationBuilder()
           .SetBasePath(Environment.CurrentDirectory)
           .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
           .AddEnvironmentVariables()
           .Build();

        services.AddDbContext<WeatherContext>(options =>
           options.UseSqlServer(configuration["Values:SqlConnection"]));
    })
    .Build();

host.Run();
