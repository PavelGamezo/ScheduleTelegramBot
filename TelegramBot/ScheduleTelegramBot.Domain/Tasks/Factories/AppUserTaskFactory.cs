using ScheduleTelegramBot.Domain.Tasks.Entities;

namespace ScheduleTelegramBot.Domain.Tasks.Factories
{
    public class AppUserTaskFactory : IAppUserTaskFactory
    {
        public AppUserTask Create(Guid id, string description, DateTime leadTime, AppUser.Entities.AppUser user)
            => new(id, description, leadTime, false, user);
    }
}
