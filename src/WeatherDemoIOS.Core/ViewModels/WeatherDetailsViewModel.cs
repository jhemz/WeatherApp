using System.Text;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using WeatherDemoIOS.Core.Events;
using WeatherDemoIOS.Core.ViewModels;
using WeatherDemoIOS.Core.ViewModels.Main;
using WeatherDemoIOS.Models;
using WeatherDemoIOS.Services;

namespace WeatherDemoIOS.ViewModels
{
    public class WeatherDetailsViewModel : BaseViewModel<WeatherDetailsEventArgs>
    {
        private IWeatherService _weatherService;
        private IAppSettings _appSettings;
        private IUserDialogs _userDialogs;
        private IMvxNavigationService _navigationService;


        public WeatherDetailsViewModel(
            IWeatherService weatherService,
            IAppSettings appSettings,
            IUserDialogs userDialogs,
            IMvxNavigationService navigationService)
        {
            _weatherService = weatherService;
            _appSettings = appSettings;
            _userDialogs = userDialogs;
            _navigationService = navigationService;

            GoBackCommand = new MvxAsyncCommand(GoBackAsync);


            PageTitle = "Weather Details";
        }

        public IMvxAsyncCommand GoBackCommand { get; set; }

        protected async Task GoBackAsync()
        {
            await _navigationService.Navigate<MainViewModel>();
        }

        public override void Prepare(WeatherDetailsEventArgs parameter)
        {
            WeatherSummary = parameter.WeatherSummary;

            var sbFeelsLike = new StringBuilder();
            sbFeelsLike.Append("Feels Like: ");
            sbFeelsLike.Append(parameter.Main.FeelsLike);
            FeelsLike = sbFeelsLike.ToString();

            var sbTempMin = new StringBuilder();
            sbTempMin.Append("Temp Min: ");
            sbTempMin.Append(parameter.Main.TempMin);
            TempMin = sbTempMin.ToString();

            var sbTempMax = new StringBuilder();
            sbTempMax.Append("Temp max: ");
            sbTempMax.Append(parameter.Main.TempMax);
            TempMax = sbTempMax.ToString();

            var sbPressure = new StringBuilder();
            sbPressure.Append("Pressure: ");
            sbPressure.Append(parameter.Main.Pressure);
            Pressure = sbPressure.ToString();

            var sbHumidity = new StringBuilder();
            sbHumidity.Append("Humidity: ");
            sbHumidity.Append(parameter.Main.Humidity);
            Humidity = sbHumidity.ToString();
        }


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

        private string _feelsLike;
        public string FeelsLike
        {
            get => _feelsLike;
            set
            {
                _feelsLike = value;
                RaisePropertyChanged(nameof(FeelsLike));

            }
        }

        private string _tempMin;
        public string TempMin
        {
            get => _tempMin;
            set
            {
                _tempMin = value;
                RaisePropertyChanged(nameof(TempMin));

            }
        }

        private string _tempMax;
        public string TempMax
        {
            get => _tempMax;
            set
            {
                _tempMax = value;
                RaisePropertyChanged(nameof(TempMax));

            }
        }

        private string _pressure;
        public string Pressure
        {
            get => _pressure;
            set
            {
                _pressure = value;
                RaisePropertyChanged(nameof(_pressure));

            }
        }

        private string _humidity;
        public string Humidity
        {
            get => _humidity;
            set
            {
                _humidity = value;
                RaisePropertyChanged(nameof(Humidity));

            }
        }

    }
}
