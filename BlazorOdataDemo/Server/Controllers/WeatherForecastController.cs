using BlazorOdataDemo.Server.Data;
using BlazorOdataDemo.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace BlazorOdataDemo.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[] {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly ApplicationDbContext db;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ApplicationDbContext db, ILogger<WeatherForecastController> logger)
        {
            this.db = db;
            _logger = logger;
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<WeatherForecast> Get() => db.WeatherForecasts;

        [HttpPost]
        public async Task Post([FromBody] int quantity)
        {
            const int batchSize = 1000;
            var i = 0;
var            count = db.WeatherForecasts.Count();
            do
            {
                if (count > quantity)
                {
                    var wf = db.WeatherForecasts.Take(Math.Min(count - quantity, batchSize)).ToList();
                    db.RemoveRange(wf);
                    await db.SaveChangesAsync();
                    count -= wf.Count;
                }
                else if (count < quantity)
                {
                    var wf = new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(i++),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                    };
                    db.Add(wf);
                    count ++;
                    if (i % batchSize == 0)
                    {
                        await db.SaveChangesAsync();
                    }
                }
            } while (count != quantity);
            await db.SaveChangesAsync();
        }
    }
}