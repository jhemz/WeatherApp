using Foundation;
using MvvmCross.Platforms.Ios.Core;
using WeatherDemoIOS.Core;

namespace WeatherDemoIOS.iOS
{
    [Register(nameof(AppDelegate))]
    public class AppDelegate : MvxApplicationDelegate<Setup, App>
    {
    }
}
