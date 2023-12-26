using System;
using System.Threading.Tasks;
using Discord;
using Discord.Rest;
using Discord.WebSocket;
using Discord.Webhook;
using Discord.Commands;

namespace Discord_Bot
{
    public class Fun : ModuleBase<SocketCommandContext>
    {
        [Command("mimic")]
        [Summary("Say something as someone else.")]
        public async Task Mimic(SocketGuildUser targetUser, [Remainder]string message) {
            await Context.Message.DeleteAsync();
            var channel = Context.Channel as SocketTextChannel;
            var webhook = await channel.CreateWebhookAsync(targetUser.Username);
            // Download the image from the avatar URL
            var cli = new DiscordWebhookClient(webhook);
            // Send a message using the webhook and set the avatar
            await cli.SendMessageAsync(message, false, null, targetUser.DisplayName, targetUser.GetAvatarUrl());
            
        }
    }
}    