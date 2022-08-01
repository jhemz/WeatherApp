using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherDemoIOS.Models;

namespace WeatherDemoIOS.Services
{
    public class WeatherService : IWeatherService
    {
        private HttpClient client;

        public WeatherService()
        {
            




        }

        public async Task<ServerResponse<WeatherFields>> GetWeatherForCityAsync(string city)
        {
            ServerResponse<WeatherFields> result;

            string url = string.Format(AppConstants.WeatherURL, city, AppConstants.APIKey);

            client = new HttpClient();

            client.BaseAddress = new Uri(url);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string strResponse_JSON = await response.Content.ReadAsStringAsync();

                WeatherFields weatherFields = JsonConvert.DeserializeObject<WeatherFields>(strResponse_JSON);

                result = new ServerResponse<WeatherFields>()
                {
                    Model = weatherFields,
                    Success = true
                };
            }
            else
            {
                result = new ServerResponse<WeatherFields>()
                {
                    Success = false,
                    ErrorMessage = response.ReasonPhrase
                };
            }

            return result;
        }
    }
}
