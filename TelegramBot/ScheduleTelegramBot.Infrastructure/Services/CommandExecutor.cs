using Microsoft.Extensions.DependencyInjection;
using ScheduleTelegramBot.Application.Services;
using ScheduleTelegramBot.Application.Common.Commands;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ScheduleTelegramBot.Infrastructure.Services
{
    public sealed class CommandExecutor : ICommandExecutor
    {
        private readonly List<BaseCommand> _commands;
        private BaseCommand _lastCommand;

        public CommandExecutor(IServiceProvider serviceProvider)
        {
            _commands = serviceProvider.GetServices<BaseCommand>().ToList();
        }

        public async Task Execute(Update update)
        {
            if(update.Message?.Chat is null && update?.CallbackQuery is null)
            {
                return; 
            }

            if(update.Type == UpdateType.CallbackQuery)
            {
                switch (update.CallbackQuery.Data)
                {
                    case CommandNames.AddOperationCommand:
                        await ExecuteCommand(CommandNames.AddOperationCommand, update);
                        return;
                    case CommandNames.SelectCategoryCommand:
                        await ExecuteCommand(CommandNames.SelectCategoryCommand, update);
                        return;
                    case CommandNames.GetTomorrowTasks:
                        await ExecuteCommand(CommandNames.GetTomorrowTasks, update);
                        return;
                    case CommandNames.GetNextWeekTasks:
                        await ExecuteCommand(CommandNames.GetNextWeekTasks, update);
                        return;
                    case CommandNames.GetNextMonthTasks:
                        await ExecuteCommand(CommandNames.GetNextMonthTasks, update);
                        return;
                    case CommandNames.GetAllTasks:
                        await ExecuteCommand(CommandNames.GetAllTasks, update);
                        return;
                }
            }

            if (update.Message != null && update.Message.Text.Contains(CommandNames.StartCommand))
            {
                await ExecuteCommand(CommandNames.StartCommand, update);
                return;
            }

            switch (_lastCommand?.Name)
            {
                case CommandNames.AddOperationCommand:
                {
                    await ExecuteCommand(CommandNames.FinishOperationCommand, update);
                    break;
                }
                case null:
                {
                    await ExecuteCommand(CommandNames.StartCommand, update);
                    break;
                }
            }
        }

        private async Task ExecuteCommand(string commandName, Update update)
        {
            _lastCommand = _commands.First(command => command.Name == commandName);
            await _lastCommand.ExecuteAsync(update);
        }
    }
}
