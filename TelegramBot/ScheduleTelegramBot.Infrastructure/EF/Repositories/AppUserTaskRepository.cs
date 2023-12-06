using Microsoft.EntityFrameworkCore;
using ScheduleTelegramBot.Domain.Common.Repositories;
using ScheduleTelegramBot.Domain.Tasks.Entities;
using ScheduleTelegramBot.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTelegramBot.Infrastructure.EF.Repositories
{
    public class AppUserTaskRepository : IAppUserTaskRepository
    {
        private readonly ScheduleDbContexts _dbContext;
        private readonly DbSet<AppUserTask> _tasks;

        public AppUserTaskRepository(ScheduleDbContexts context)
        {
            _dbContext = context;
            _tasks = _dbContext.Tasks;
        }

        public async Task AddAsync(AppUserTask appUserTask)
        {
            var alreadyExist = _tasks.Any(task => task.Id == appUserTask.Id);

            if (!alreadyExist)
            {
                await _tasks.AddAsync(appUserTask);
                await SaveAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<AppUserTask>> GetUserTasksByDate(DateTime leadTime)
        {
            var resultTasks = _tasks.Where(task =>
                task.LeadTime.Day == leadTime.Day &&
                task.LeadTime.Month == leadTime.Month &&
                task.LeadTime.Year == leadTime.Year)
                .ToListAsync();

            return resultTasks;
        }
    }
}
