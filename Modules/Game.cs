using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using System.Globalization;
using Discord.Rest;
using Discord.Webhook;



namespace Discord_Bot
{
    
    // Create a module with the 'ask' prefix
    [Group("ask")]
    public class Game : ModuleBase<SocketCommandContext>
    {
        Random random = new Random();
        // ask truth User -> [Truth Question], User?
        [Command("truth")]
        [Summary("Ask a truth question to the user.")]
        public async Task TruthAsync(
            [Summary("The user you're asking truth question to.")] 
            SocketUser user = null)
        {   
            string truthFilePath = "./banks/truth.txt";
            string[] truthArray = File.ReadAllLines(truthFilePath);

            int randomInt = random.Next(0, truthArray.Length);
            var userInfo = user ?? Context.Client.CurrentUser;
            await Context.Channel.SendMessageAsync($"{userInfo.Username}, {truthArray[randomInt]}?");
        }

        // ask dare User -> [Dare Question], User?
        [Command("dare")]
        [Summary
        ("Ask a dare question to the user.")]
        public async Task DareAsync(
            [Summary("The user you're asking dare question to.")]
            SocketUser user = null)
        {
            string dareFilePath = "./banks/dare.txt";
            string[] dareArray = File.ReadAllLines(dareFilePath);

            int randomInt = random.Next(0, dareArray.Length);
            var userInfo = user ?? Context.Client.CurrentUser;
            await Context.Channel.SendMessageAsync($"{userInfo.Username}, do you dare {dareArray[randomInt]}?");
        
        }
        // ask truth User -> [Truth Question], User?
        [Command("sussytruth")]
        [Summary("Ask a sussy truth question to the user.")]
        public async Task SussyTruthAsync(
            [Summary("The user you're asking sussy truth question to.")] 
            SocketUser user = null)
        {   
            string truthFilePath = "./banks/sussytruth.txt";
            string[] truthArray = File.ReadAllLines(truthFilePath);

            int randomInt = random.Next(0, truthArray.Length);
            var userInfo = user ?? Context.Client.CurrentUser;
            await Context.Channel.SendMessageAsync($"{userInfo.Username}, {truthArray[randomInt]}?");
        }

        // ask dare User -> [Dare Question], User?
        [Command("sussydare")]
        [Summary
        ("Ask a sussy dare question to the user.")]
        public async Task SussyDareAsync(
            [Summary("The user you're asking sussydare question to.")]
            SocketUser user = null)
        {
            string dareFilePath = "./banks/sussydare.txt";
            string[] dareArray = File.ReadAllLines(dareFilePath);

            int randomInt = random.Next(0, dareArray.Length);
            var userInfo = user ?? Context.Client.CurrentUser;
            await Context.Channel.SendMessageAsync($"{userInfo.Username}, do you dare {dareArray[randomInt]}?");
        
        }

    }


}