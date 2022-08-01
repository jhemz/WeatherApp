using System;
using System.Threading.Tasks;
using WeatherDemoIOS.Models;

namespace WeatherDemoIOS.Services
{
    public interface IWeatherService
    {
        Task<ServerResponse<WeatherFields>> GetWeatherForCityAsync(string city);
    }
}
