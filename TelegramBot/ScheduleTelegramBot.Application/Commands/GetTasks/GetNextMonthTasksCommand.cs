using ScheduleTelegramBot.Application.Common.Commands;
using ScheduleTelegramBot.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace ScheduleTelegramBot.Application.Commands
{
    public sealed class GetNextMonthTasksCommand : BaseCommand
    {
        private readonly TelegramBotClient _telegramBot;
        private readonly IUserService _userService;

        public GetNextMonthTasksCommand(ITelegramBotClientService telegramBotClientService,
            IUserService userService)
        {
            _telegramBot = telegramBotClientService.GetBot().Result;
            _userService = userService;
        }

        public override string Name => CommandNames.GetNextMonthTasks;

        public override async Task ExecuteAsync(Update update)
        {
            var resultMessage = $"Your tasks for next month:\n";

            var user = await _userService.GetOrCreate(update);

            var tasks = user.GetUserTasks(DateTime.Now.AddDays(30));

            foreach (var task in tasks)
            {
                resultMessage += $"---------------------------------------------------\n" +
                    $"{task.LeadTime.Day}.{task.LeadTime.Month}, {task.LeadTime.DayOfWeek} " +
                    $"- {task.LeadTime.Hour}:{task.LeadTime.Minute} - \"{task.Description}\"";
            }

            await _telegramBot.SendTextMessageAsync(
                chatId: update.CallbackQuery.Message.Chat.Id,
                text: resultMessage,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
