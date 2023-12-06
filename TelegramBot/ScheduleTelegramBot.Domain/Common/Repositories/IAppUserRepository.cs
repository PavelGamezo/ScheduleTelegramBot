using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTelegramBot.Domain.Common.Repositories
{
    public interface IAppUserRepository
    {
        Task SaveAsync();
        Task AddAsync(AppUser.Entities.AppUser appUser);
        Task<AppUser.Entities.AppUser> GetByChatId(long chatId);
    }
}
