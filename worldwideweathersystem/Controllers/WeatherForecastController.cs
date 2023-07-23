using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace worldwideweathersystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly HttpClient client = new HttpClient();
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get(string city)
        {
            var apiKey = _configuration["OpenWeather:ApiKey"];
            HttpResponseMessage response = await client.GetAsync($"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserialize the response to OpenWeatherResponse
            OpenWeatherResponse weatherData = JsonConvert.DeserializeObject<OpenWeatherResponse>(responseBody);

            // Convert the data to WeatherForecast
            WeatherForecast weatherForecast = new WeatherForecast
            {
                Date = DateTime.Now,
                // Convert temperature from Kelvin to Celsius
                TemperatureC = (int)(weatherData.Main.Temp - 273.15),
                Summary = weatherData.Weather[0].Main
            };

            return new List<WeatherForecast> { weatherForecast };
        }
    }

    public class OpenWeatherResponse
    {
        public Main Main { get; set; }
        public Weather[] Weather { get; set; }
    }

    public class Main
    {
        public double Temp { get; set; }
    }

    public class Weather
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }
}
