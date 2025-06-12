using HotelRez.Models;
using HotelRez.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRez.Repositories
{
    public interface IOpenWeatherRepository
    {
        Task<Current> GetLocationData();
        Task<bool> SaveWeatherData(WeatherDto weatherDto);
    }
}
