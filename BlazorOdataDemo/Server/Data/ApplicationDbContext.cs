using BlazorOdataDemo.Shared;
using Microsoft.EntityFrameworkCore;
#nullable disable
namespace BlazorOdataDemo.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    }
}
