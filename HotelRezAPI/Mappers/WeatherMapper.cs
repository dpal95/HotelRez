
using HotelRezAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HotelRez.Mappers
{
    public static class WeatherMapper
    {      

        public static string SerializeToXml(IEnumerable<WeatherDto> data)
        {
            var weatherList = new WeatherDataList { Items = new List<WeatherDto>(data) };

            var xmlSerializer = new XmlSerializer(typeof(WeatherDataList));
            using var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, weatherList);
            return stringWriter.ToString();
        }
    }
}
