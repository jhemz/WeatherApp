using System;
namespace WeatherDemoIOS.Services
{
    public interface IAppSettings
    {
        void SaveLocalCity(string city);

        string GetLocalCity();
    }
}
