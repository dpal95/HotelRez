using System.Net;
using System.Text;
using HotelRez.Mappers;
using HotelRezAPI.Services;
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
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "getlastdayweatherbycity")] HttpRequestData req)
        {
            var query = System.Web.HttpUtility.ParseQueryString(req.Url.Query);
            var city = query["city"];

            if (string.IsNullOrWhiteSpace(city))
            {
                var badResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await badResponse.WriteStringAsync("Query parameter 'city' is required.");
                return badResponse;
            }

            var weatherData = _getWeatherService.GetLocationData(city);

            if (weatherData == null || weatherData.Count() == 0)
            {
                var notFound = req.CreateResponse(HttpStatusCode.NotFound);
                await notFound.WriteStringAsync($"No weather data found for '{city}'.");
                return notFound;
            }



            string xml = WeatherMapper.SerializeToXml(weatherData);

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/xml");
            await response.WriteStringAsync(xml, Encoding.UTF8);

            return response;

        }
    }
}
