using ScheduleTelegramBot.Domain.AppUser.Events;
using ScheduleTelegramBot.Domain.Common.Domain;
using ScheduleTelegramBot.Domain.Tasks.Entities;

namespace ScheduleTelegramBot.Domain.AppUser.Entities
{
    public class AppUser : AggregateRoot
    {
        public long ChatId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public List<AppUserTask> Tasks { get; set; }

        private AppUser(Guid id) : base(id)
        {
        }

        internal AppUser(Guid id,
            long chatId,
            string userName,
            string firstName,
            string lastName) : base(id)
        {
            ChatId = chatId;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;

            AddDomainEvent(new AppUserCreatedDomainEvent(this));
        }

        public List<AppUserTask> GetUserTasks(DateTime leadTime)
        {
            var resultTasks = Tasks.Where(task => task.LeadTime.Day <= leadTime.Day)
                                   .OrderBy(task => task.LeadTime)
                                   .ToList();

            return resultTasks;
        }

        public List<AppUserTask> GetUserTasks()
        {
            return Tasks.OrderBy(task => task.LeadTime)
                        .ToList();
        }
    }
}
