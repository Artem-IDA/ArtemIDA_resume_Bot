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
        public static string Token = "";
        public static string WebHookUrl = "";
        
        public static TelegramBotClient Client;

        public static BotCommand[] AvailableCommands = new BotCommand[7];

        public static string NotTextMessage = "Прости, но я люблю читать текстовые сообщения, все остальное меня мало интересует.\nДавай поговорим о чем-то из этого списка:";
        public static string StartMessage = "Ну что ж, о чем поговорим? Может что-то из этого:";
        public static string NotFoundAnswerMessage = "Я не знаю как тебе ответить на это сообщение...\nДавай поговорим на темы, в которых я разбираюсь. Их список можно увидеть введя /help";
        public static string About_me = "Я, студент третьего курса “Киевского техникума электронных приборов” по специальности “Инженерия программного обеспечения”." +
                                        "Активно изучаю С++&C# и принимаю участие в олимпиадах городского уровня по этому ЯП." +
                                        "Я стараюсь максимально качественно выполнять поставленную задачу и всегда стремлюсь получать максимум практического опыта и знаний от выполнения." +
                                        "Имею базовые знания в языке Python v.3.x.";
        public static string Work_places = "В данный момент не имею опыта работы в местах с официальным трудоустройством. Так что основной опыт приобретен в процессе обучения в техникуме (4 курс). \n" +
                                           "Вы можете предложить мне первый оффер).";
        public static string Achievements = "●	3 место на городском конкурсе студенческих проектов. \n" +
                                            "●	1 командное место на городской олимпиаде по С++. \n" +
                                            "●	Идеальные оценки по предметам, которые относятся к Computer Science. \n" +
                                            "Так же екзамены/практики в этой сфере закрываются автоматами \n";
        public static string Skills = "●  Умею пользоваться GitHub. Ссылку на мой профиль с самыми интересными работами можно получить командой /portfolio.\n" +
                                      "●  Пишу курсовые работы, абсолютно все из них были высоко оценены преподавателями моего техникума.\n" +
                                      "●  Знание английского языка на уровне B1 (Intermediate), при прочтении тех. документации особых проблем не испытываю.\n" +
                                      "●  Первый и основной опыт программирования получен на С++, так что я знаком как минимум с базой этого ЯП\n" +
                                      "●  Для быстрого показа работы алгоритмов выучил бузисы Python-на, хотя не особо люблю скриптовые языки.\n" +
                                      "●  Сейчас активно переучиваюсь на C#, к примеру REST api этого бота написано на ASP.NET Core 3.1.\n" +
                                      "●  Пишу код восновном в ООП стиле (если это возможно), владею базовыми паттернами ООП. Есть опыт роботы с библиотекой Qt на С++.\n" +
                                      "●  Владею азами SQL, работал с MySQL. (Хватит мозгов не добавлять в очередь - DELETE FROM \"table_name\" * ";

        public static string Portfolio = "Вот ссылка на мой Github: https://github.com/Gameluser?tab=repositories";
        public static string Contacts = "Тел.: 050-740-91-51 (Vodafone) \n" +
                                        "Почта : artem-soroka-2013@ukr.net \n" +
                                        "Telegram : @Artem_IDA, https://t.me/Artem_IDA \n" +
                                        "Diskord : Artem_IDA#5012 (самый верный вариант) \n";


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
