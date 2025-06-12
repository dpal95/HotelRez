using HotelRezAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRezAPI.Repositories
{
    public interface IGetWeatherRepository
    {
        IEnumerable<WeatherDto> GetLocationData(string city);
    }
}
