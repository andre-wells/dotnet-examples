using Microsoft.AspNetCore.Mvc;

namespace WebApiTimeoutCancellation.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Request {System.Diagnostics.Activity.Current?.Id}: Fetching weather information");
            await Task.Delay(5000, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            var results = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            _logger.LogInformation($"Request {System.Diagnostics.Activity.Current?.Id}: Number of results: {results.Count()}");

            return results;
        }
    }
}