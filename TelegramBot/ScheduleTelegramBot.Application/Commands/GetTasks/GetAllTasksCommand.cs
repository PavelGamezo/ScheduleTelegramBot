using ScheduleTelegramBot.Application.Common.Commands;
using ScheduleTelegramBot.Application.Services;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace ScheduleTelegramBot.Application.Commands
{
    public sealed class GetAllTasksCommand : BaseCommand
    {
        private readonly TelegramBotClient _telegramBot;
        private readonly IUserService _userService;

        public GetAllTasksCommand(ITelegramBotClientService telegramBotClientService,
            IUserService userService)
        {
            _telegramBot = telegramBotClientService.GetBot().Result;
            _userService = userService;
        }

        public override string Name => CommandNames.GetNextMonthTasks;

        public override async Task ExecuteAsync(Update update)
        {
            var resultMessage = $"Your tasks:\n";

            var user = await _userService.GetOrCreate(update);

            var tasks = user.GetUserTasks();

            foreach (var task in tasks)
            {
                resultMessage += $"---------------------------------------------------\n" +
                    $"Date of lead time: {task.LeadTime.Day}.{task.LeadTime.Month}, {task.LeadTime.DayOfWeek} \n" +
                    $"Description: {task.LeadTime.Hour}:{task.LeadTime.Minute} - \"{task.Description}\"";
            }

            await _telegramBot.SendTextMessageAsync(
                chatId: update.CallbackQuery.Message.Chat.Id,
                text: resultMessage,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
