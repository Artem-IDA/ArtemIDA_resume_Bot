using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Microsoft.AspNetCore.Http;

namespace MyTelegramBot.Controllers
{
    [ApiController]
    [Route("/")]
    public class BotController : Controller
    {
        private readonly TelegramBotClient client = new TelegramBotClient("1283606192:AAGi-nstALp5oLHm5LBUJwGCKDlgTqZNmvQ");
        [HttpPost]
        public async Task<OkResult> Post([FromBody]Update update)
        {
            if (update == null) 
                return Ok();
            var message = update.Message;
            if (message?.Type == MessageType.Text)
            {
                await client.SendTextMessageAsync(message.Chat.Id, message.Text);
            }
            return Ok();
        }

        [HttpGet]
        public string Get()
        {
            return "Its ok!";
        }
    }
}