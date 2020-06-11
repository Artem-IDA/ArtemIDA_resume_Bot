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

        public static BotCommand[] AvailableCommands = new BotCommand[7];

        public static string NotTextMessage = "Прости, но я люблю читать текстовые сообщения, все остальное меня мало интересует.\nДавай поговорим о чем-то из этого списка:";
        public static string StartMessage = "Ну что ж, о чем поговорим? Может что-то из этого:";
        public static string NotFoundAnswerMessage = "Я не знаю как тебе ответить на это сообщение...\nДавай поговорим на темы, в которых я разбираюсь. Их список можно увидеть введя /help";

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

            BotCommand help = new BotCommand();
            help.Command = "/help";
            help.Description = "Показать все доступные команды.";

            AvailableCommands[0] = about_me;
            AvailableCommands[1] = work_places;
            AvailableCommands[2] = achievements;
            AvailableCommands[3] = skills;
            AvailableCommands[4] = portfolio;
            AvailableCommands[5] = contacts;
            AvailableCommands[6] = help;
        }

        public static async void SendAvailableCommands(ChatId id)
        {
            string AvailableCommandsStr = "";
            for (int i = 0; i < 7; i++)
            {
                AvailableCommandsStr += AvailableCommands[i].Command + " - " + AvailableCommands[i].Description + "\n";
            }
            await Client.SendTextMessageAsync(id, AvailableCommandsStr);
        }
    }
}
