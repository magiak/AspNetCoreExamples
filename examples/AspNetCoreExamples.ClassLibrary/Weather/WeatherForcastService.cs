using System;

namespace AspNetCoreExamples.ClassLibrary.Weather
{
    public class WeatherForcastService : IWeatherForcastService
    {
        public WeatherForecast GetCurrent()
        {
            // Use for example https://openweathermap.org/api
            return new WeatherForecast { Summary = "Cold weather", TemperatureC = -5, Date = DateTime.Now };
        }
    }
}
