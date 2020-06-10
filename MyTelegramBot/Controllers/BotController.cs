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
            if (Bot.Client == null)
            {
                return StatusCode(414);               //Дурень! Ты опять на те же грабли наступаешь? Бот не инициализирован, как и его поля!!!
            }

            if (update.Message.Type == MessageType.Text)
            {
                await Bot.Client.SendTextMessageAsync(update.Message.Chat.Id, update.Message.Text);
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