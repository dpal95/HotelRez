using HotelRez.Models.DTOs;
using Microsoft.EntityFrameworkCore;


namespace HotelRez.Database
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options) { }

        public DbSet<WeatherDto> WeatherEntries { get; set; }
    }
}
