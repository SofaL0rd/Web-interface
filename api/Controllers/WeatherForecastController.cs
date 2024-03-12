using api.Models;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private static List<WeatherForecast> forecasts = new List<WeatherForecast>(); 


        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return forecasts;
        }

        [HttpPost]
        public IActionResult Post(WeatherForecast weatherForecast)
        {

            forecasts.Add(weatherForecast);
            return Ok();
        }

        [HttpPost("AutoCreate")]
        public IActionResult Post([FromBody] int count)
        {
            if (count <= 0)
            {
                return BadRequest("Count must be greater than zero.");
            }

            for (int i = 0; i < count; i++)
            {
                var newForecast = new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(Random.Shared.Next(1, 10))),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                };
                forecasts.Add(newForecast);
            }

            return Ok();
        }
    }
}