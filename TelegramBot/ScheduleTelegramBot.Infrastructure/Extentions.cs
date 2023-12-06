using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ScheduleTelegramBot.Application.Services;
using ScheduleTelegramBot.Domain.Common.Repositories;
using ScheduleTelegramBot.Infrastructure.EF.Contexts;
using ScheduleTelegramBot.Infrastructure.EF.Repositories;
using ScheduleTelegramBot.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTelegramBot.Infrastructure
{
    public static class Extentions
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ScheduleDbContexts>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("Database"));
            },
            ServiceLifetime.Singleton);

            services.AddSingleton<IAppUserRepository, AppUserRepository>();
            services.AddSingleton<IAppUserTaskRepository, AppUserTaskRepository>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<ICommandExecutor, CommandExecutor>();
            services.AddSingleton<ITelegramBotClientService, TelegramBotService>();

            return services;
        }
    }
}
