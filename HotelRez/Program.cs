using HotelRez.Repositories;
using HotelRez.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddHttpClient("weatherClient", client =>
        {
            client.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/weather");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
        });

        services.AddScoped<IOpenWeatherService, OpenWeatherService>();
        services.AddScoped<IOpenWeatherRepository, OpenWeatherRepository>();
    })
    .Build();

host.Run();
