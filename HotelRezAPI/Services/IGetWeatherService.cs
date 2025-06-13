using HotelRezAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRezAPI.Services
{
    public interface IGetWeatherService
    {
        IActionResult GetLocationData(string city);
    }
}
