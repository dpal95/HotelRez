using HotelRez.Models;
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
            return await SaveLocationData(data);
        }

        private async Task<Current?> GetLocationData()
        {
          return await _openWeatherRepository.GetLocationData();
        }
        private async Task<bool> SaveLocationData(Current? data)
        {

        }
    }
}
