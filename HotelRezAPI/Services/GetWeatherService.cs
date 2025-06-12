using HotelRezAPI.Mappers;
using HotelRezAPI.Models;
using HotelRezAPI.Models;
using HotelRezAPI.Repositories;
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
        public IEnumerable<WeatherDto> GetLocationData(string city)
        {
           return _openWeatherRepository.GetLocationData(city);
     
        } 
    }
}
