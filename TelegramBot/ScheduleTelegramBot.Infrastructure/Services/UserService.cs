using Microsoft.Extensions.Configuration;
using ScheduleTelegramBot.Domain.AppUser.Entities;
using ScheduleTelegramBot.Domain.AppUser.Factories;
using ScheduleTelegramBot.Domain.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot;
using Telegram.Bot.Types;
using ScheduleTelegramBot.Application.Services;
using ScheduleTelegramBot.Infrastructure.EF.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ScheduleTelegramBot.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IAppUserFactory _appUserFactory;
        private readonly ScheduleDbContexts _dbContext;

        public UserService(IAppUserFactory appUserFactory, ScheduleDbContexts dbContext)
        {
            _appUserFactory = appUserFactory;
            _dbContext = dbContext;
        }

        public async Task<AppUser> GetOrCreate(Update update)
        {
            var newUser = update.Type switch
            {
                UpdateType.CallbackQuery => _appUserFactory.Create(
                    Guid.NewGuid(),
                    update.CallbackQuery.Message.Chat.Id,
                    update.CallbackQuery.Message.Chat.Username,
                    update.CallbackQuery.Message.Chat.FirstName,
                    update.CallbackQuery.Message.Chat.LastName
                ),
                UpdateType.Message => _appUserFactory.Create(
                    Guid.NewGuid(),
                    update.Message.Chat.Id,
                    update.Message.Chat.Username,
                    update.Message.Chat.FirstName,
                    update.Message.Chat.LastName
                )
            };

            var user = await _dbContext.Users
                .Include(user => user.Tasks)
                .FirstOrDefaultAsync(user => user.ChatId == newUser.ChatId);

            if (user is not null)
            {
                return user;
            }

            var result = await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            return result.Entity;
        }
    }
}
