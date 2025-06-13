using System;
using HotelRez.Services;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace HotelRez
{
    public class WeatherScheduledFunc
    {
        private readonly ILogger _logger;
        private readonly IOpenWeatherService _openWeatherService;

        public WeatherScheduledFunc(ILoggerFactory loggerFactory, IOpenWeatherService openWeatherService)
        {
            _logger = loggerFactory.CreateLogger<WeatherScheduledFunc>();
            _openWeatherService = openWeatherService;
        }

        [Function("WeatherSchedule")]
        public async Task RunAsync([TimerTrigger("0 0 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            bool response = await _openWeatherService.GetSaveLocationDataHandler();

            if (response)
            {
                _logger.LogInformation("Success");
            }
            else
            {
                _logger.LogError("Error Saving Data");
            }

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
