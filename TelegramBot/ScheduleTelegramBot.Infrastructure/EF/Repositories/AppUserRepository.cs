using Microsoft.EntityFrameworkCore;
using ScheduleTelegramBot.Domain.AppUser.Entities;
using ScheduleTelegramBot.Domain.Common.Repositories;
using ScheduleTelegramBot.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Infrastructure.EF.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly ScheduleDbContexts _dbContext;
        private readonly DbSet<AppUser> _appUser;

        public AppUserRepository(ScheduleDbContexts dbContexts)
        {
            _dbContext = dbContexts;
            _appUser = _dbContext.Users;
        }

        public async Task AddAsync(AppUser appUser)
        {
            var alreadyExist = _dbContext.Users.Any(user => user.ChatId == appUser.ChatId);

            if(!alreadyExist)
            {
                await _appUser.AddAsync(appUser);
                await SaveAsync();
            }
        }

        public Task<AppUser> GetByChatId(long chatId)
        {
            return _dbContext.Users.FirstOrDefaultAsync(user => user.ChatId == chatId);
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
