using System;
using DSharpPlus;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DSharpPlus.VoiceNext;
using DSharpPlus.Entities;

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

            discord.MessageCreated += async (s, e) =>
            {
                if (respond.isActivity(e.Message.Content))
                {
                    respond.performActivity(e.Message.Content);

                }
            };

            await discord.ConnectAsync();
            await Task.Delay(-1);
            
            JoinVoiceAfterStart(discord);
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
            await Task.Delay(3000);
            DiscordChannel channel = await discord.GetChannelAsync(1012965027625582622);
            VoiceNextConnection connection = await channel.ConnectAsync();
        }
    }
}