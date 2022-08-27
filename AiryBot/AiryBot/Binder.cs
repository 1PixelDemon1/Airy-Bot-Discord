using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.VoiceNext;
using DSharpPlus.Entities;

namespace AiryBot
{
    internal class Binder
    {
        public Binder(ref Respond respond, DiscordClient discord)
        {
            respond.addActivity(new Activity("апдейт", new List<string>(), async (i) => 
            {
                await discord.SendMessageAsync(await discord.GetChannelAsync(1012965027625582622), $"тест! ");
                //await discord.SendMessageAsync(await discord.GetChannelAsync(1012241805028376638),
                //  $"Update! {(await discord.GetUserAsync(442360320107741195)).Mention} {(await discord.GetUserAsync(739409836160188509)).Mention}");
                Console.WriteLine("Привет"); 
            }));

            respond.addActivity(new Activity("join", new List<string>(), async (i) =>
            {
                discord.UseVoiceNext();

                DiscordChannel channel = await discord.GetChannelAsync(1012965027625582622);
                VoiceNextConnection connection = await channel.ConnectAsync();
            }));
        }
    }
}
