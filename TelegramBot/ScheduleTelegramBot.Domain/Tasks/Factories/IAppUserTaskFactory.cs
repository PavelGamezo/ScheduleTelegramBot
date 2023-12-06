using ScheduleTelegramBot.Domain.Tasks.Entities;

namespace ScheduleTelegramBot.Domain.Tasks.Factories
{
    public interface IAppUserTaskFactory
    {
        AppUserTask Create(
            Guid id,
            string description,
            DateTime leadTime,
            AppUser.Entities.AppUser user);
    }
}
