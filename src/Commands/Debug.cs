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
        public async Task Ping(InteractionContext ctx)
        {
            Log.Information(string.Format("Author={0}, Command=\'Ping\'", ctx.Member.Id));
            await ctx.CreateResponseAsync(
                InteractionResponseType.ChannelMessageWithSource,
                new DiscordInteractionResponseBuilder().WithContent("Hi"));
        }
    }
}
