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
        Random random = new Random();

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
        [Command("rate")]
        [Summary("Rate someone based on anything you want.")]
        public async Task Rate(SocketGuildUser targetUser, [Remainder]string thing) {
            int rating = random.Next(0, 101);
            var embed = new EmbedBuilder
            {
                Title = "rating: " + thing,
                Description = "**" + rating + "%**",
                Timestamp = DateTimeOffset.Now,
                Color = Color.Green,
                Footer = new EmbedFooterBuilder()
                    .WithText(targetUser.DisplayName)
                    .WithIconUrl(targetUser.GetAvatarUrl())
            };
            await Context.Channel.SendMessageAsync(embeds: new[] { embed.Build() });
            
        }

        [Command("ship")]
        [Summary("See how good of a match two people are!")]

        public async Task Ship(SocketGuildUser user1, [Remainder]SocketGuildUser user2 = null) {
            if (user2 == null) {
                user2 = user1;
                user1 = Context.User as SocketGuildUser;
            }
            int rating = random.Next(0, 101);
            string desc = "";
            if (rating < 20) {
                desc = "it's a terrible match! don't even bother trying. :face_with_spiral_eyes: ";
            } else if (rating < 40) {
                desc = "it's MEH. could be better though! :face_with_diagonal_mouth:";
            } else if (rating < 60) {
                desc = "not bad! i think it's time to go on a date :cowboy:";
            } else if (rating < 80) {
                desc = "anyone else feel it? kinda gettin' spicy in here with these two. :wink:";
            } else {
                desc = "just kiss already :smirk:";
            }
            var embed = new EmbedBuilder
            {
                Title = "ship: " + user1.DisplayName + " x " + user2.DisplayName,
                Description = desc + "\n**rating:** " + rating + "%",
                Timestamp = DateTimeOffset.Now,
                Color = Color.Green
            };
            await Context.Channel.SendMessageAsync(embeds: new[] { embed.Build() });
            
        }
    }
}    