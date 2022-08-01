using System;
namespace WeatherDemoIOS.Models
{
    public class ServerResponse<T>
    {
        public T Model { get; set; }

        public string ErrorMessage { get; set; }

        public bool Success { get; set; }
    }
}
