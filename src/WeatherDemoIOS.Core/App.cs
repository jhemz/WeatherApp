using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using WeatherDemoIOS.Core.ViewModels.Main;
using WeatherDemoIOS.Services;

namespace WeatherDemoIOS.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {

            Mvx.IoCProvider.ConstructAndRegisterSingleton<IWeatherService, WeatherService>();
            Mvx.IoCProvider.ConstructAndRegisterSingleton<IAppSettings, AppSettings>();
            Mvx.IoCProvider.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }
    }
}
