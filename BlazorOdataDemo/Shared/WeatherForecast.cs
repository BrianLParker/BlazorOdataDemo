using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BlazorOdataDemo.Shared;

[Display(Name = "Weather Forecasts", Description = "Weather Forecasts")]
[Index(nameof(Date))]
public class WeatherForecast
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Date", Description = "Date", Prompt = "Date", Order = 1)]
    public DateTimeOffset Date { get; set; }

    [Display(Name = "Temp. (C)",
        Description = "Temperature in Celcius",
        Prompt = "Temperature in Celcius",
        Order = 2)]
    public int TemperatureC { get; set; }

    [Display(Name = "Summary",
        Description = "Summary",
        Prompt = "Summary",
        Order = 4)]
    public string? Summary { get; set; }

    [NotMapped]
    [Display(Name = "Temp. (F)",
        Description = "Temperature in Fahrenheit",
        Prompt = "Temperature in Fahrenheit",
        Order = 3)]
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
