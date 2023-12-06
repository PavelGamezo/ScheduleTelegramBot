using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using ScheduleTelegramBot.Domain.AppUser.Factories;
using ScheduleTelegramBot.Domain.Common.Repositories;
using ScheduleTelegramBot.Infrastructure.Services;
using System.Text.Json.Serialization;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using ScheduleTelegramBot.Application.Services;

namespace ScheduleTelegramBot.TelegramBot
{
    [ApiController]
    [Route("/")]
    public class TelegramBotController : ControllerBase
    {
        private readonly ICommandExecutor _commandExecutor;
        
        
        public TelegramBotController(ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }

        [HttpGet]
        public void Get()
        {
            Console.WriteLine("Hello world");
        }

        [HttpPost()]
        public async Task<IActionResult> Update([FromBody]Update update)
        {
            var chat = update.Message?.Chat;

            if (chat is null && update.CallbackQuery == null)
            {
                return Ok();
            }

            await _commandExecutor.Execute(update);

            return Ok();
        }
    }
}
