using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.VoiceNext;
using DSharpPlus.Entities;
using System.Net.Http.Headers;

namespace AiryBot
{
    internal class Binder
    {
        public Binder(ref Respond respond, DiscordClient discord)
        {
            respond.addActivity(new Activity("тест", new List<object>() { discord, "1012965027625582622", $"ТЕСТ!"}, BotMessenger.sendMessage));
            respond.addActivity(new Activity("апдейт", new List<object>() { discord, "1012241805028376638" }, BotMessenger.sendUpdate));   

            respond.addActivity(new Activity("join", new List<object>(), async (i) =>
            {
                discord.UseVoiceNext();

                DiscordChannel channel = await discord.GetChannelAsync(1012965027625582622);
                VoiceNextConnection connection = await channel.ConnectAsync();
            }));


        }
    }
}
