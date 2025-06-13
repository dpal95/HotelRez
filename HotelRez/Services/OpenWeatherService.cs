using HotelRez.Mappers;
using HotelRez.Models;
using HotelRez.Models.DTOs;
using HotelRez.Repositories;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<OpenWeatherService> _logger;
        public OpenWeatherService(IOpenWeatherRepository openWeatherRepository, ILogger<OpenWeatherService> logger)
        {
            _openWeatherRepository = openWeatherRepository;
            _logger = logger;
        }
        public async Task<bool> GetSaveLocationDataHandler()
        {
            try
            {
                var data = await GetLocationData();
                var saveData = MapToDBSchema(data);
                return await SaveLocationData(saveData);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                return false;
            }
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
