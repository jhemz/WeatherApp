using System;
using WeatherDemoIOS.Models;

namespace WeatherDemoIOS.Core.Events
{
    public class WeatherDetailsEventArgs : EventArgs
    {
        public WeatherDetailsEventArgs(Main main, string weatherSummary)
        {
            Main = main;
            WeatherSummary = weatherSummary;
        }

        public Main Main { get; set; }
        public string WeatherSummary { get; set; }

    }
}
