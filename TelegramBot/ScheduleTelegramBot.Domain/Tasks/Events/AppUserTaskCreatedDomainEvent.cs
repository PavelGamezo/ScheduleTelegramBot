using ScheduleTelegramBot.Domain.Common.Domain;
using ScheduleTelegramBot.Domain.Tasks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTelegramBot.Domain.Tasks.Events
{
    public class AppUserTaskCreatedDomainEvent : IDomainEvents
    {
        public AppUserTaskCreatedDomainEvent(AppUserTask task)
        {
            Task = task;
        }

        public AppUserTask Task { get; set; }
    }
}
