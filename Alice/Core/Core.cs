// Core.cs

using DSharpPlus;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Reflection;


namespace Alice.Core
{
    public sealed class AliceService : IHostedService
    {
        private readonly Microsoft.Extensions.Logging.ILogger _logger;
        private readonly IHostApplicationLifetime _applicationLifetime;
        private readonly DiscordClient _discordClient;
        private readonly SlashCommandsExtension _slashes;

        public AliceService(ILogger<AliceService> logger, IHostApplicationLifetime applicationLifetime)
        {
            this._logger = logger;
            this._applicationLifetime = applicationLifetime;
            this._discordClient = new DiscordClient(new DiscordConfiguration()
            {
                Token = Environment.GetEnvironmentVariable("TOKEN"),
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All,
                
                LoggerFactory = new LoggerFactory().AddSerilog(),
                MinimumLogLevel = LogLevel.Information,
                LogUnknownEvents = false
            });

            this._slashes = this._discordClient.UseSlashCommands();
            this._slashes.RegisterCommands(Assembly.GetExecutingAssembly());
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await _discordClient.ConnectAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _discordClient.DisconnectAsync();
        }
    }
}
