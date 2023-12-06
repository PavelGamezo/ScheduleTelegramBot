using Microsoft.Extensions.DependencyInjection;
using ScheduleTelegramBot.Application.Commands;
using ScheduleTelegramBot.Application.Commands.Start;
using ScheduleTelegramBot.Application.Common.Commands;
using ScheduleTelegramBot.Domain.AppUser.Factories;
using ScheduleTelegramBot.Domain.Tasks.Factories;

namespace ScheduleTelegramBot.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddSingleton<IAppUserFactory, AppUserFactory>();
            services.AddSingleton<IAppUserTaskFactory, AppUserTaskFactory>();
            services.AddSingleton<BaseCommand, AddOperaionCommand>();
            services.AddSingleton<BaseCommand, StartCommand>();
            services.AddSingleton<BaseCommand, FinishOperationCommand>();
            services.AddSingleton<BaseCommand, GetTomorrowTasksCommand>();
            services.AddSingleton<BaseCommand, SelectCategoryCommand>();

            return services;
        }
    }
}
