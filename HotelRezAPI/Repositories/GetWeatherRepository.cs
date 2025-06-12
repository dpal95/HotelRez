using Azure;
using HotelRezAPI.Database;
using HotelRezAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HotelRezAPI.Repositories
{
    public class GetWeatherRepository : IGetWeatherRepository
    {
        private readonly WeatherContext _context;

        public GetWeatherRepository(WeatherContext weatherContext)
        {
            _context = weatherContext;
        }

        public IEnumerable<WeatherDto> GetLocationData(string city)
        {
           return _context.WeatherEntries.Where(x => x.City == city && x.Timestamp >= DateTime.Now.AddDays(-1));

        }
    }
}
