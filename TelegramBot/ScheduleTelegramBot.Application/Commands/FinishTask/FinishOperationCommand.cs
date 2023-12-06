using ScheduleTelegramBot.Application.Common.Commands;
using ScheduleTelegramBot.Application.Services;
using ScheduleTelegramBot.Domain.Common.Repositories;
using ScheduleTelegramBot.Domain.Tasks.Factories;
using System.Globalization;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Application.Commands
{
    public class FinishOperationCommand : BaseCommand
    {
        private readonly IUserService _userService;
        private readonly IAppUserTaskFactory _taskFactory;
        private readonly IAppUserTaskRepository _taskRepository;
        private readonly TelegramBotClient _telegramBot;

        public FinishOperationCommand(
            IUserService userService,
            IAppUserTaskFactory taskFactory,
            IAppUserTaskRepository taskRepository,
            ITelegramBotClientService telegramBotClientService)
        {
            _userService = userService;
            _taskFactory = taskFactory;
            _taskRepository = taskRepository;
            _telegramBot = telegramBotClientService.GetBot().Result;
        }

        public override string Name => CommandNames.FinishOperationCommand;

        public override async Task ExecuteAsync(Update update)
        {
            var dateAndDescription = update.Message.Text.Split(" - ");
            var user = await _userService.GetOrCreate(update);

            var leadDate = DateTime.ParseExact(dateAndDescription[0], "dd/MM/yyyy HH:mm", new CultureInfo("ru"));
            var taskDescription = dateAndDescription[1];

            var appUserTask = _taskFactory.Create(Guid.NewGuid(), taskDescription, leadDate, user);

            await _taskRepository.AddAsync(appUserTask);

            var message = $"Your task have been added!\n" +
                          $"Date of lead time: {appUserTask.LeadTime}\n" +
                          $"Description is \"{appUserTask.Description}\"\n";

            await _telegramBot.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: message,
                parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
