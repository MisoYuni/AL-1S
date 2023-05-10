// Program.cs

using Alice.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Alice
{
   public sealed class Program
   {
        public static async Task Main()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(Environment.GetEnvironmentVariable("dir_logs") ?? "logs/.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            await Host.CreateDefaultBuilder()
                .UseSerilog()
                .UseConsoleLifetime()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddLogging(logging => logging.ClearProviders().AddSerilog());
                    services.AddHostedService<AliceService>();
                })
                .RunConsoleAsync();

            await Log.CloseAndFlushAsync();
        }
   }
}
