using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace WeatherDemoIOS.Services
{
    public class AppSettings : IAppSettings
    {

        private readonly string _settingKey = "CityName";

        public string GetLocalCity()
        {
            return Settings.GetValueOrDefault(_settingKey, null);
        }

        private ISettings Settings => CrossSettings.Current;

        public void SaveLocalCity(string city)
        {
            Settings.AddOrUpdateValue(_settingKey, city);
        }
    }
}
