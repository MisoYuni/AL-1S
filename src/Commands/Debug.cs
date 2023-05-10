// Debug.cs

using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Serilog;

namespace Alice.Commands
{
    public class Debug : ApplicationCommandModule
    {
        [SlashCommand("ping", "Ping")]
        internal async Task Ping(InteractionContext ctx)
        {
            Log.Information($"Command: Author={ctx.Member.Id}, Command=\'Ping\'");
            await ctx.CreateResponseAsync(
                InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder()
                .WithContent($"WebSocket: {ctx.Client.Ping}ms"));
        }
    }
}
