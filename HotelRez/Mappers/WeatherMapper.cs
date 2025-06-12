using HotelRez.Models;
using HotelRez.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRez.Mappers
{
    public static class WeatherMapper
    {
        public static WeatherDto MapToDto(Current? xml)
        {
            if(xml == null) return new WeatherDto();
            return new WeatherDto
            {
                Temperature = xml.Temperature.Value,
                Humidity = xml.Humidity.Value,
                WindSpeed = xml.Wind.Speed.Value,
                WindDirection = xml.Wind.Direction.Value,
                Description = xml.Weather.Value,
                Timestamp = xml.Lastupdate.Value,
                City = xml.City.Name,
            };
        }
    }
}
