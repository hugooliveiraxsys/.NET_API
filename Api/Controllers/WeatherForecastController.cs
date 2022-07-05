using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
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

        [HttpGet]
        [Route("{id}")]
        public WeatherForecast GetById(int id)
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray().FirstOrDefault();
        }

        [HttpGet]
        [Route("combo")]
        public IEnumerable<ComboItem> Combo()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new ComboItem
            {
                Id = index,
                Text = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        [Route("list")]
        public IEnumerable<WeatherForecast> List()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public int Create([FromBody] WeatherForecast weatherForecast)
        {
            var rng = new Random();
            return rng.Next(1, 5);
        }

        [HttpPut]
        public int Update(WeatherForecast weatherForecast)
        {
            var rng = new Random();
            return rng.Next(1, 5);
        }

        [HttpDelete]
        [Route("{id}")]
        public bool Delete(int id)
        {
            return true;
        }
    }
}
