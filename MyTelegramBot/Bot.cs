using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;

namespace MyTelegramBot
{
    public static class Bot
    {
        public static string Name = "@ArtemIDA_resume_Bot";

        public static string Token = "1283606192:AAGi-nstALp5oLHm5LBUJwGCKDlgTqZNmvQ";

        public static string WebHookUrl = "https://myresumetelegrambot.azurewebsites.net";
        
        public static TelegramBotClient Client;

        public static void Startup()
        {
            Client = new TelegramBotClient(Token);
            Client.SetWebhookAsync(WebHookUrl).Wait();
        }
    }
}
