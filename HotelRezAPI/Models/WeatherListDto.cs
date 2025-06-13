using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HotelRezAPI.Models
{
    [XmlRoot("WeatherReports")]
    public class WeatherDataList
    {
        [XmlElement("Weather")]
        public List<WeatherDto> Items { get; set; }
    }
}
