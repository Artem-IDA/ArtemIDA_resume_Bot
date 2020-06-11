using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace MyTelegramBot.Controllers
{
    [ApiController]
    [Route("/")]
    public class BotController : Controller
    {
        [HttpPost]
        public async Task<StatusCodeResult> Post([FromBody]Update update)
        {
            if (update == null)
            {
                return StatusCode(204);               //Опять пустые запросы шлешь, ШАЛУН?!
            }
            else if (Bot.Client == null)
            {
                return StatusCode(500);               //Дурень! Ты опять на те же грабли наступаешь? Бот не инициализирован, как и его поля!!!
            }

            if(update.Message.Type != MessageType.Text)
            {
                await Bot.Client.SendTextMessageAsync(update.Message.Chat.Id, Bot.NotTextMessage);
                Bot.SendAvailableCommands(update.Message.Chat.Id);
            }
            else if (update.Message.Type == MessageType.Text)
            {
                if (update.Message.Text[0] != ':' && update.Message.Text[update.Message.Text.Length - 1] != ':')
                {
                    switch (update.Message.Text)
                    {
                        case "/start": await Bot.Client.SendTextMessageAsync(update.Message.Chat.Id, Bot.StartMessage);
                                       Bot.SendAvailableCommands(update.Message.Chat.Id); break;
                        case "/about_me": break;
                        case "/work_places": break;
                        case "/achievements": break;
                        case "/skills": break;
                        case "/portfolio": break;
                        case "/contacts": break;
                        case "/help": Bot.SendAvailableCommands(update.Message.Chat.Id); break;
                        default: await Bot.Client.SendTextMessageAsync(update.Message.Chat.Id, Bot.NotFoundAnswerMessage); break;
                    }
                }
                else
                {
                    await Bot.Client.SendTextMessageAsync(update.Message.Chat.Id, Bot.NotFoundAnswerMessage);
                }

            }
            return StatusCode(200);                   //GG, все прошло гладко!
        }

        [HttpGet]
        public string Get()
        {
            return "It's so empty here... Just like in my pocket and soul.";
        }
    }
}