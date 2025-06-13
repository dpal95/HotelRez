using HotelRez.Mappers;
using HotelRezAPI.Models;
using HotelRezAPI.Models;
using HotelRezAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HotelRezAPI.Services
{
    public class GetWeatherService : IGetWeatherService
    {
        private readonly IGetWeatherRepository _openWeatherRepository;
        public GetWeatherService(IGetWeatherRepository openWeatherRepository)
        {
            _openWeatherRepository = openWeatherRepository;
        }
        public IActionResult GetLocationData(string city)
        {
            try
            {
                var resp = _openWeatherRepository.GetLocationData(city);

                if (resp == null || resp.Count() == 0)
                {
                    return new NotFoundObjectResult($"No weather data found for '{city}'.");
                }

                string xml = WeatherMapper.SerializeToXml(resp);

                return new ContentResult
                {
                    Content = xml,
                    ContentType = "application/xml",
                    StatusCode = (int)HttpStatusCode.OK
                };
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex.Message);
            }

        } 
    }
}
