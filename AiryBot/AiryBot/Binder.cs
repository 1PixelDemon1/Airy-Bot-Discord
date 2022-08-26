using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;

namespace AiryBot
{
    internal class Binder
    {

        public Binder(ref Respond respond, DiscordClient discord)
        {


            respond.addActivity(new Activity("апдейт", new List<string>(), async (i) => 
            {
                await discord.SendMessageAsync(await discord.GetChannelAsync(1012241805028376638),
                    $"Update! {(await discord.GetUserAsync(442360320107741195)).Mention} {(await discord.GetUserAsync(739409836160188509)).Mention}");
                Console.WriteLine("Привет"); 
            }));
        }

    }
}
