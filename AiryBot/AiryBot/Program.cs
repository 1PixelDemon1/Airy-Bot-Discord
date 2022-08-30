using System;
using DSharpPlus;
using System.Threading.Tasks;

namespace AiryBot
{
    class Bot
    {
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
            });

            discord.MessageCreated += async (s, e) =>
            {
                if (e.Message.Content.ToLower().StartsWith("айри!"))
                    await e.Message.RespondAsync("Привет!");

            };

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }



        static string GetToken()
        {
            StreamReader reader = new StreamReader("token.json");
                string text = reader.ReadLine();
            // Returns token of Discord Bot. 
            // Here was Ivan.
            return text;
        }
    }
}