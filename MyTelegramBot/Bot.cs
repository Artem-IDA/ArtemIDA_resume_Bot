using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace MyTelegramBot
{
    public static class Bot
    {
        public static string Name = "@ArtemIDA_resume_Bot";

        public static string Token = "1283606192:AAGi-nstALp5oLHm5LBUJwGCKDlgTqZNmvQ";

        public static string WebHookUrl = "https://myresumetelegrambot.azurewebsites.net";
        
        public static TelegramBotClient Client;

        public static BotCommand[] AvailableCommands = new BotCommand[6];

        public static string NotTextMessage = "Прости, но я люблю читать текстовые сообщения, все остальное меня мало интересует. Давай поговорим о чем-то из этого списка:";

        public static void Startup()
        {
            Client = new TelegramBotClient(Token);
            Client.SetWebhookAsync(WebHookUrl).Wait();

            InitCommandsList();
            Client.SetMyCommandsAsync(AvailableCommands);
        }

        public static void InitCommandsList()
        {
            BotCommand about_me = new BotCommand();
            about_me.Command = "/about_me";
            about_me.Description = "Немного обо мне.";

            BotCommand work_places = new BotCommand();
            work_places.Command = "/work_places";
            work_places.Description = "Где учился/работал.";

            BotCommand achievements = new BotCommand();
            achievements.Command = "/achievements";
            achievements.Description = "Мои достижения.";

            BotCommand skills = new BotCommand();
            skills.Command = "/skills";
            skills.Description = "Мои навыки и умения.";

            BotCommand portfolio = new BotCommand();
            portfolio.Command = "/portfolio";
            portfolio.Description = "Мои реализованные проекты.";

            BotCommand contacts = new BotCommand();
            contacts.Command = "/contacts";
            contacts.Description = "Как со мной связаться.";

            AvailableCommands[0] = about_me;
            AvailableCommands[1] = work_places;
            AvailableCommands[2] = achievements;
            AvailableCommands[3] = skills;
            AvailableCommands[4] = portfolio;
            AvailableCommands[5] = contacts;
        }

        public static async void SendAvailableCommands(ChatId id)
        {
            string AvailableCommandsStr = "";
            for (int i = 0; i < 6; i++)
            {
                AvailableCommandsStr += AvailableCommands[i].Command + " - " + AvailableCommands[i].Description + "\n";
            }
            await Client.SendTextMessageAsync(id, AvailableCommandsStr);
        }
    }
}
