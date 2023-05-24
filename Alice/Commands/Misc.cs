// Misc.cs

using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using Serilog;


namespace Alice.Commands
{
    [SlashCommandGroup("misc", "sus")]
    public class Misc :ApplicationCommandModule
    {
        [SlashCommand("someone", "Ping randomly selected user")]
        internal async Task Someone(InteractionContext ctx)
        {
            var rand = new Random();
            var userlist = ctx.Channel.Users;
            await ctx.CreateResponseAsync(new DiscordInteractionResponseBuilder()
            .WithContent($"> Hi {userlist[rand.Next(userlist.Count)].Mention}")
            .AddMentions(Mentions.All));
        }
    }
}