using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using WeatherDemoIOS.Core.Events;
using WeatherDemoIOS.Models;
using WeatherDemoIOS.Services;
using WeatherDemoIOS.ViewModels;

namespace WeatherDemoIOS.Core.ViewModels.Main
{
    public class MainViewModel : BaseViewModel
    {
        private IWeatherService _weatherService;
        private IAppSettings _appSettings;
        private IUserDialogs _userDialogs;
        private IMvxNavigationService _navigationService;

        public MainViewModel(
            IWeatherService weatherService,
            IAppSettings appSettings,
            IUserDialogs userDialogs,
            IMvxNavigationService navigationService)
        {

            _weatherService = weatherService;
            _appSettings = appSettings;
            _userDialogs = userDialogs;
            _navigationService = navigationService;

            SearchCommand = new MvxAsyncCommand(SearchAsync);
            SaveCityCommand = new MvxAsyncCommand(SaveCityAsync);
            MoreInfoCommand = new MvxAsyncCommand(MoreInfoAsync);

            ConfigureData();

            PageTitle = "Weather Demo";
        }

        #region Properties

        //the city to search for
        public string City { get; set; }

        //the returned data from the api
        public WeatherFields Weather { get; set; }

        private string _weatherSummary;
        public string WeatherSummary
        {
            get => _weatherSummary;
            set
            {
                _weatherSummary = value;
                RaisePropertyChanged(nameof(WeatherSummary));

            }
        }

        private bool _showMoreButton;
        public bool ShowMoreButton
        {
            get => _showMoreButton;
            set
            {
                _showMoreButton = value;
                RaisePropertyChanged(nameof(ShowMoreButton));

            }
        }


        #endregion

        #region Commands

        public IMvxAsyncCommand SearchCommand { get; set; }

        public IMvxAsyncCommand SaveCityCommand { get; set; }

        public IMvxAsyncCommand MoreInfoCommand { get; set; }

        #endregion

        #region Functions

        private async Task MoreInfoAsync()
        {
            var eventArgs = new WeatherDetailsEventArgs(Weather.Main, WeatherSummary);
            await _navigationService.Navigate<WeatherDetailsViewModel, WeatherDetailsEventArgs>(eventArgs);
        }

        private void ConfigureData()
        {
            string savedLocalCity = _appSettings.GetLocalCity();

            //if there was a saved local city, then pre fill the city field
            if (!string.IsNullOrEmpty(savedLocalCity))
            {
                City = savedLocalCity;
            }
        }

        private async Task SearchAsync()
        {
            //only perform the api call if the string city is not empty/null
            if (!string.IsNullOrEmpty(City))
            {
                ServerResponse<WeatherFields> weatherRepsonse = await _weatherService.GetWeatherForCityAsync(City);
                if (weatherRepsonse.Success)
                {
                    var sb = new StringBuilder();

                    Weather = weatherRepsonse.Model;
                    if(Weather != null)
                    {
                        if(Weather.Main != null)
                        {
                            sb.Append(Weather.Main.Temp);
                            sb.Append(" degrees Kelvin");
                        }
                        if (Weather.Weather.ToList().Any())
                        {
                            Weather mostRecentWeather = Weather.Weather.FirstOrDefault();
                            sb.Append("; ");
                            sb.Append(mostRecentWeather.Description);
                        }
                        WeatherSummary = sb.ToString();
                        ShowMoreButton = true;
                    }
                }
                else
                {
                    //show alert, there was an api error
                    _userDialogs.Alert(weatherRepsonse.ErrorMessage);
                    WeatherSummary = "";
                    ShowMoreButton = false;
                }
            }
            else
            {
                //show alert, the user needs to input a city
                _userDialogs.Alert("Please anter a valid city name");
                WeatherSummary = "";
                ShowMoreButton = false;
            }
        }

        private async Task<bool> SaveCityAsync()
        {
            bool result;
            //only save the city if city is not null or empty
            if (!string.IsNullOrEmpty(City))
            {
                _appSettings.SaveLocalCity(City);
                result = true;
            }
            else
            {
                result = false;
                //alert user that city was empty, to save, enter a value
                _userDialogs.Alert("Please anter a valid city name");
            }

            return result;
        }

        #endregion
    }
}
