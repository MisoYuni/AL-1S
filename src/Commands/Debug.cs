// Debug.cs

using DSharpPlus.SlashCommands;
using Serilog;


namespace Alice.Commands
{
    [SlashCommandGroup("debug", "A group of commands for debugging purposes")]
    public class Debug : ApplicationCommandModule
    {
        [SlashCommand("ping", "Ping")]
        internal async Task Ping(InteractionContext ctx)
        {
            Log.Information($"Command: Author={ctx.Member.Id}, Command=\'Ping\'");
            await ctx.CreateResponseAsync($"WebSocket: {ctx.Client.Ping}ms");
        }
    }
}
