using HotelRez.Models;
using HotelRez.Models.DTOs;
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

        public static string SerializeToXml<WeatherDto>(WeatherDto data)
        {
            var xmlSerializer = new XmlSerializer(typeof(WeatherDto));
            using var stringWriter = new StringWriter();
            xmlSerializer.Serialize(stringWriter, data);
            return stringWriter.ToString();
        }
    }
}
