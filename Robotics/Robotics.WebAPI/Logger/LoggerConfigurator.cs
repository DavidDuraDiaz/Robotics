using Serilog;

namespace Robotics.WebAPI.Logger
{
    public class LoggerConfigurator
    {
        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Debug()
                .CreateLogger();
        }
    }
}