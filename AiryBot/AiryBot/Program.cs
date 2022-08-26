using System;
using DSharpPlus;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Serilog;
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

   




            
            respond.addActivity(new Activity("привет", new List<string>(), ((i) => { Console.WriteLine("Привет"); return false; })));

            var discord = new DiscordClient(new DiscordConfiguration()

            {
                Token = GetToken(),
                TokenType = TokenType.Bot,
            });

            discord.MessageCreated += async (s, e) =>
            {
                if (respond.isActivity(e.Message.Content)) {
                    respond.performActivity(e.Message.Content);

                } 


                //if (e.Message.Content.ToLower().StartsWith("айри!"))
                //    await e.Message.RespondAsync("Привет!");

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