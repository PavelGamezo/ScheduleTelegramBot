using ScheduleTelegramBot.Application.Common.Commands;
using ScheduleTelegramBot.Application.Services;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ScheduleTelegramBot.Application.Commands.Start
{
    public class StartCommand : BaseCommand
    {
        private readonly IUserService _userService;
        private readonly TelegramBotClient _telegramBot;

        public StartCommand(IUserService userService, ITelegramBotClientService telegramBotClientService)
        {
            _userService = userService;
            _telegramBot = telegramBotClientService.GetBot().Result;
        }

        public override string Name => CommandNames.StartCommand;

        public override async Task ExecuteAsync(Update update)
        {
            var user = await _userService.GetOrCreate(update);
            var inlineKeyboards = new InlineKeyboardMarkup(new[]
            {
                new InlineKeyboardButton("Create task")
                {
                    CallbackData = CommandNames.AddOperationCommand
                },
                new InlineKeyboardButton("Get task")
                {
                    CallbackData = CommandNames.SelectCategoryCommand
                }
            });

            await _telegramBot.SendTextMessageAsync(
                chatId: user.ChatId,
                text: "Hello! This is my personal schedule! Please, choose your next operation",
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown,
                replyMarkup: inlineKeyboards);
        }
    }
}
