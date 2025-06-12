using HotelRezAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRezAPI.Services
{
    public interface IGetWeatherService
    {
        IEnumerable<WeatherDto> GetLocationData(string city);
    }
}
