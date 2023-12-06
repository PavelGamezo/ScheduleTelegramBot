using ScheduleTelegramBot.Application.Common.Commands;
using ScheduleTelegramBot.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Application.Commands
{
    public class AddOperaionCommand : BaseCommand
    {
        private readonly TelegramBotClient _telegramBot;

        public AddOperaionCommand(IUserService userService, ITelegramBotClientService telegramBotClientService)
        {
            _telegramBot = telegramBotClientService.GetBot().Result;
        }

        public override string Name => CommandNames.AddOperationCommand;

        public override async Task ExecuteAsync(Update update)
        {
            const string message = "For adding new operation enter day and title of your task in format:\n" +
                                   "day/month/year HH:mm - Task description\n" +
                                   "Example:\n" +
                                   "12/12/2023 15:30 - Получить по шее";

            await _telegramBot.SendTextMessageAsync(
                chatId: update.CallbackQuery.Message.Chat.Id,
                text: message,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
