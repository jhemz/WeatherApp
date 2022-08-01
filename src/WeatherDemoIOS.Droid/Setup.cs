using Microsoft.Extensions.Logging;
using MvvmCross.Platforms.Android.Core;
using WeatherDemoIOS.Core;
using Serilog;
using Serilog.Extensions.Logging;

namespace WeatherDemoIOS.Droid
{
    public class Setup : MvxAndroidSetup<App>
    {
        protected override ILoggerProvider CreateLogProvider() => new SerilogLoggerProvider();

        protected override ILoggerFactory CreateLogFactory()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.AndroidLog()
                .CreateLogger();

            return new SerilogLoggerFactory();
        }
    }
}
