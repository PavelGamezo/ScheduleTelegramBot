using ScheduleTelegramBot.Domain.AppUser.Entities;
using ScheduleTelegramBot.Domain.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTelegramBot.Domain.AppUser.Events
{
    public class AppUserCreatedDomainEvent : IDomainEvents
    {
        public AppUserCreatedDomainEvent(Entities.AppUser appUser) 
        {
            User = appUser;
        }

        public AppUser.Entities.AppUser User { get; set; }
    }
}
