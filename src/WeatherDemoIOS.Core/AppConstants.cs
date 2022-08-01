using System;
namespace WeatherDemoIOS
{
    public static class AppConstants
    {
        public static string APIKey = "955c1ac35177fb2d355bec57eb9a11bd";

        //0 = city name, 1 = api key
        public static string WeatherURL = "https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}";
    }
}
