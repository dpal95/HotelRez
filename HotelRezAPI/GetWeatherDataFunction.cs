using System.Net;
using System.Text;
using HotelRez.Mappers;
using HotelRezAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace HotelRezAPI
{
    public class GetWeatherDataFunction
    {
        private readonly ILogger _logger;
        private readonly IGetWeatherService _getWeatherService;

        public GetWeatherDataFunction(ILoggerFactory loggerFactory, IGetWeatherService getWeatherService)
        {
            _logger = loggerFactory.CreateLogger<GetWeatherDataFunction>();
            _getWeatherService = getWeatherService;
        }

        [Function("GetLastDayWeatherByCity")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "getlastdayweatherbycity")] HttpRequestData req)
        {
            var query = System.Web.HttpUtility.ParseQueryString(req.Url.Query);
            var city = query["city"];

            if (string.IsNullOrWhiteSpace(city))
            {
                return new BadRequestObjectResult("Query parameter 'city' is required.");
            }

           return _getWeatherService.GetLocationData(city);  


        }
    }
}
