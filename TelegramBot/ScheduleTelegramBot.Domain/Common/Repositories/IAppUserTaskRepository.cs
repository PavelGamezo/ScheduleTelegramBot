using ScheduleTelegramBot.Domain.Tasks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTelegramBot.Domain.Common.Repositories
{
    public interface IAppUserTaskRepository
    {
        Task AddAsync(AppUserTask appUserTask);
        Task SaveAsync();
        Task<List<AppUserTask>> GetUserTasksByDate(DateTime leadTime);
    }
}
