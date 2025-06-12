using Azure;
using HotelRez.Database;
using HotelRez.Models;
using HotelRez.Models.DTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HotelRez.Repositories
{
    public class OpenWeatherRepository : IOpenWeatherRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;
        private readonly string _long;
        private readonly string _lat;
        private readonly WeatherContext _context;

        public OpenWeatherRepository(IHttpClientFactory httpClientFactory, IConfiguration configuration, WeatherContext weatherContext)
        {
            _httpClientFactory = httpClientFactory;
            _httpClient = _httpClientFactory.CreateClient("weatherClient");
            //doing it this way since its small app, would consider using models if needed
            _configuration = configuration;
            //bit hardcoded but again small example
            _apiKey = _configuration["WeatherApiKey"];
            _long = _configuration["LondonLong"];
            _lat = _configuration["LondonLat"];
            _context = weatherContext;
        }

        public async Task<Current> GetLocationData()
        {
            var xmlSerializer = new XmlSerializer(typeof(Current));

            var weatherResp = await _httpClient.GetAsync(BuildRequestUrl());

            weatherResp.EnsureSuccessStatusCode();

            using (TextReader reader = new StringReader(await weatherResp.Content.ReadAsStringAsync()))
            {
                return (Current)xmlSerializer.Deserialize(reader);
            }

        }

        public async Task<bool> SaveWeatherData(WeatherDto weatherDto)
        {
            try
            {
                await _context.WeatherEntries.AddAsync(weatherDto);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        

        private string BuildRequestUrl()
        {
            return $"?lat={_lat}&lon={_long}&mode=xml&appid={_apiKey}";
        }
    }
}
