using System;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Globalization;

namespace Discord_Bot
{
    public class Utilityuser : ModuleBase<SocketCommandContext>
    {
        [Command("ping")]
        [Summary("Show current latency.")]
        public async Task Ping()
            => await ReplyAsync($"Latency: {Context.Client.Latency} ms");
    }
        public class InfoModule : ModuleBase<SocketCommandContext>
    {
        // say hello world -> hello world
        [Command("say")]
        [Summary("Echoes a message.")]
        public Task SayAsync([Remainder] [Summary("The text to echo")] string echo)
            => ReplyAsync(echo);
            
        // ReplyAsync is a method on ModuleBase 
    }
    // Create a module with the 'user' prefix
    [Group("user")]
    public class UserModule : ModuleBase<SocketCommandContext>
    {
        // user sussy baka banana -> banana is a sussy baka
        [Command("sussy baka")]
        [Summary("Say this person is a sussy baka.")]
        public async Task SussyAsync(
            [Summary("The user that is a sussy baka.")] 
            SocketUser user = null)
        {
            // We can also access the channel from the Command Context.
            await Context.Channel.SendMessageAsync($"{user} is a sussy baka :/");
        }

        // user userinfo --> foxbot#0282
        // user userinfo @Khionu --> Khionu#8708
        // user userinfo Khionu#8708 --> Khionu#8708
        // user userinfo Khionu --> Khionu#8708
        // user userinfo 96642168176807936 --> Khionu#8708
        // user whois 96642168176807936 --> Khionu#8708
        [Command("userinfo")]
        [Summary
        ("Returns info about the current user, or the user parameter, if one passed.")]
        [Alias("user", "whois")]
        public async Task UserInfoAsync(
            [Summary("The (optional) user to get info from")]
            SocketUser user = null)
        {
            var userInfo = user ?? Context.Client.CurrentUser;
            await ReplyAsync($"{userInfo.Username}#{userInfo.Discriminator}");
        }
    }
}