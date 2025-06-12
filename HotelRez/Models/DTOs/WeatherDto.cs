using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRez.Models.DTOs
{
    public class WeatherDto
    {
        public int Id { get; set; }
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public double WindSpeed { get; set; }
        public int WindDirection { get; set; }
        public string Description { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
