namespace AspNetCoreExamples.ClassLibrary.Weather
{
    public interface IWeatherForcastService
    {
        WeatherForecast GetCurrent();
    }
}