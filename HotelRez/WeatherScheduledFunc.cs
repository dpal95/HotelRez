using System;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace HotelRez
{
    public class WeatherScheduledFunc
    {
        private readonly ILogger _logger;

        public WeatherScheduledFunc(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<WeatherScheduledFunc>();
        }

        [Function("WeatherSchedule")]
        public void Run([TimerTrigger("0 0 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
