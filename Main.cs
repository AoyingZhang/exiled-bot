using System;
using System.Threading.Tasks;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Discord_Bot
{
    public class Program
    {
        static void Main(string[] args)
            => new Program().MainAsync().GetAwaiter().GetResult();

        public async Task MainAsync()
        {
            using var services = ConfigureServices();

            Console.WriteLine("Ready for takeoff...");
            var client = services.GetRequiredService<DiscordSocketClient>();

            client.Log += Log;
            services.GetRequiredService<CommandService>().Log += Log;

            // Log in to Discord and start the bot.
            await client.LoginAsync(TokenType.Bot, "MTE4ODYwNTg2NTkwNTg5NzYzNQ.GYphRz.RHBjzfy_2o8x0RgpjW4iz8L_U6njxDNR5VmLL4");
            await client.StartAsync();

            await services.GetRequiredService<CommandHandlingService>().InitializeAsync();

            // Run the bot forever.
            await Task.Delay(-1);
        }

        public ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton(new DiscordSocketClient(new DiscordSocketConfig
                { 
                    MessageCacheSize = 500,
                    LogLevel = LogSeverity.Info
                }))
                .AddSingleton(new CommandService(new CommandServiceConfig
                { 
                    LogLevel = LogSeverity.Info,
                    DefaultRunMode = RunMode.Async,
                    CaseSensitiveCommands = false 
                }))
                .AddSingleton<CommandHandlingService>()
                .BuildServiceProvider();
        }

        private Task Log(LogMessage log)
        {
            Console.WriteLine(log.ToString());
            return Task.CompletedTask;
        }
    }
}