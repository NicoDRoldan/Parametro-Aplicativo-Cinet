using Parametro.Desings;
using Parametro.Desings.SubDesings;
using Serilog;
using Serilog.Events;

namespace Parametro
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Logger(l => l
                    .Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Error)
                    .WriteTo.File("LogsError/Error.txt", rollingInterval: RollingInterval.Day))
                .WriteTo.Logger(l => l
                    .Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Information)
                    .WriteTo.File("Logs/Log.txt", rollingInterval: RollingInterval.Day))
                .WriteTo.Logger(l => l
                    .Filter.ByIncludingOnly(evt => evt.Level == LogEventLevel.Warning)
                    .WriteTo.File("LogsWarning/Log.txt", rollingInterval: RollingInterval.Day))
                .CreateLogger();

            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
            //Application.Run(new LinkedQuerysForm());
        }
    }
}