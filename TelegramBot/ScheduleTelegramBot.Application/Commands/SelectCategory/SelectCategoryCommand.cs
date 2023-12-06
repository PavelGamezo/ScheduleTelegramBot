using ScheduleTelegramBot.Application.Common.Commands;
using ScheduleTelegramBot.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ScheduleTelegramBot.Application.Commands
{
    public sealed class SelectCategoryCommand : BaseCommand
    {
        private readonly IUserService _userService;
        private readonly TelegramBotClient _telegramBotClientService;

        public SelectCategoryCommand(IUserService userService,
            ITelegramBotClientService telegramBotClientService)
        {
            _userService = userService;
            _telegramBotClientService = telegramBotClientService.GetBot().Result;
        }

        public override string Name => CommandNames.SelectCategoryCommand;

        public override async Task ExecuteAsync(Update update)
        {
            var user = await _userService.GetOrCreate(update);

            var inlineKeyboards = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    new InlineKeyboardButton("Get tommorow tasks")
                    {
                        CallbackData = CommandNames.GetTomorrowTasks
                    },
                    new InlineKeyboardButton("Get next week tasks")
                    {
                        CallbackData = CommandNames.GetNextWeekTasks
                    }
                },
                new[]
                {
                    new InlineKeyboardButton("Get next month tasks")
                    {
                        CallbackData = CommandNames.GetNextMonthTasks
                    },
                    new InlineKeyboardButton("Get all tasks")
                    {
                        CallbackData = CommandNames.GetAllTasks
                    }
                }
            });

            _telegramBotClientService.SendTextMessageAsync(
                chatId: update.CallbackQuery.Message.Chat.Id,
                text: "Please, select the required operation",
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                replyMarkup: inlineKeyboards);
        }
    }
}
