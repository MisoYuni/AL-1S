// Moderation.cs

using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Serilog;

namespace Alice.Commands
{
    [SlashCommandGroup("moderation","A group of commands for moderation purposes")]
    public class Moderation : ApplicationCommandModule
    {
        [SlashCommand("delete", "Removes certain number of messages")]
        internal async Task DeleteMessage(InteractionContext ctx,
            [Option("Amount", "Amount of messages to be deleted. Range: 1-100")] long amount,
            [Option("Reason", "Reason of this moderation activity.")] string reason = "Not given")
        {
            Log.Information($"Command: Author={ctx.Member.Id}, Command=\'delete\'");
            await ctx.DeferAsync(true);

            IReadOnlyList<DiscordMessage> messages = await ctx.Channel.GetMessagesAsync((int)amount);
            
            await ctx.Channel.DeleteMessagesAsync(messages, reason);
            await ctx.FollowUpAsync(
                new DiscordFollowupMessageBuilder()
                .WithContent($"Successfully removed {amount} message(s)."));
            Log.Information($"Action: delete_message, channel={ctx.Channel.Id}, amount={amount}, reason=\'{reason}\'");
        }
    }
}
