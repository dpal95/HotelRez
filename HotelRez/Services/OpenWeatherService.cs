using HotelRez.Mappers;
using HotelRez.Models;
using HotelRez.Models.DTOs;
using HotelRez.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HotelRez.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly IOpenWeatherRepository _openWeatherRepository;
        public OpenWeatherService(IOpenWeatherRepository openWeatherRepository)
        {
            _openWeatherRepository = openWeatherRepository;
        }
        public async Task<bool> GetSaveLocationDataHandler()
        {
            var data = await GetLocationData();
            var saveData = MapToDBSchema(data);
            return await SaveLocationData(saveData);
        }

        private async Task<Current?> GetLocationData()
        {
          return await _openWeatherRepository.GetLocationData();
        }
        private async Task<bool> SaveLocationData(WeatherDto data)
        {
           return await _openWeatherRepository.SaveWeatherData(data);
        }

        private WeatherDto MapToDBSchema(Current? data)
        {
            return WeatherMapper.MapToDto(data);
        }
    }
}
