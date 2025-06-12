using HotelRezAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace HotelRezAPI.Database
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options) { }

        public DbSet<WeatherDto> WeatherEntries { get; set; }
    }
}
