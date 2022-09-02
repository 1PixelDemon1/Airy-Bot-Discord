﻿using DSharpPlus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.Entities;

namespace AiryBot
{
    internal class BotMessenger
    {
        public static async void sendMessage(List<object> parametres)
        {
            DiscordClient? client = parametres[0] as DiscordClient;
            UInt64 channel = UInt64.Parse(parametres[1] as string);
            string? message = parametres[2] as string;

            await client.SendMessageAsync(await client.GetChannelAsync(channel), message);
        }

        public static async void sendUpdate(List<object> parametres) {
            DiscordClient? discord = parametres[0] as DiscordClient;
            string? message = $"Update! \"Voice channel name changing!\" " +
                             $"{(await discord.GetUserAsync(442360320107741195)).Mention}" +
                             $" {(await discord.GetUserAsync(739409836160188509)).Mention}";
            parametres.Add(message);
            sendMessage(parametres);
        }

        //public static async void newMessege(List<object> parametres)
        //{
        //    DiscordClient? discord = parametres[0] as DiscordClient;
        //    DiscordEmbedBuilder embedMessege = new DiscordEmbedBuilder();

        //    static Optional<DiscordColor> color("Gold")


        //    parametres.Add(message);
        //    sendMessage(parametres);
        //}

    }
}
