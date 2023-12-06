using ScheduleTelegramBot.Domain.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTelegramBot.Domain.Tasks.Entities
{
    public class AppUserTask : AggregateRoot
    {
        public string Description {  get; set; }
        public DateTime LeadTime { get; set; }
        public bool IsCompleted { get; set; }

        public AppUser.Entities.AppUser User { get; set; }
        public Guid UserId { get; set; }

        private AppUserTask(Guid id) : base(id) { }

        internal AppUserTask(
            Guid id,
            string description,
            DateTime endTime,
            bool isCompleted,
            AppUser.Entities.AppUser appUser) : base(id)
        {
            Description = description;
            LeadTime = endTime;
            IsCompleted = isCompleted;
            User = appUser;
        }
    }
}
