using HotelRez.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRez.Services
{
    internal class OpenWeatherService : IOpenWeatherService
    {
        private readonly IOpenWeatherRepository _openWeatherRepository;
        internal OpenWeatherService(IOpenWeatherRepository openWeatherRepository)
        {
            _openWeatherRepository = openWeatherRepository;
        }
        public async Task GetLocationDataHandler()
        {
            await GetLocationData();
            await SaveLocationData();
        }

        private async Task GetLocationData()
        {

        }
        private async Task SaveLocationData()
        {

        }
    }
}
