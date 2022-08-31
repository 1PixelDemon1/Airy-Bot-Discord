using System;
using DSharpPlus;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DSharpPlus.VoiceNext;
using DSharpPlus.Entities;
using DSharpPlus.Net.Models;

namespace AiryBot
{
    class Bot
    {

        static private Respond respond = new Respond();

        static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = GetToken(),
                TokenType = TokenType.Bot,
                MinimumLogLevel = Microsoft.Extensions.Logging.LogLevel.Debug,
            });

            Binder binder = new Binder(ref respond, discord);

            // Заходит в голосовой канал после запyска.

            JoinVoiceAfterStart(discord);
            ChangeChannelName(discord);

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }

        

        static string GetToken()
        {
            StreamReader reader = new StreamReader("token.json");
                string text = reader.ReadLine();
            // Возвращает токен бота.
            return text;
        }


        static public async void JoinVoiceAfterStart(DiscordClient discord)
        {
            discord.UseVoiceNext();
            await Task.Delay(5000);
            DiscordChannel channel = await discord.GetChannelAsync(1012965027625582622);
            VoiceNextConnection connection = await channel.ConnectAsync();
        }

        static public async void ChangeChannelName(DiscordClient discord)
        {
            // Меняет название канала на сервере.
            DiscordChannel channel = await discord.GetChannelAsync(1012965027625582622);
            Action<ChannelEditModel> action = new(x => x.Name = "Hi");
            Console.WriteLine("Succes!");
            await channel.ModifyAsync(action);
        }

    }
}