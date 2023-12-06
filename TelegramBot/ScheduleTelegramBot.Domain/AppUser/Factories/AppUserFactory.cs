using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTelegramBot.Domain.AppUser.Factories
{
    public class AppUserFactory : IAppUserFactory
    {
        public Entities.AppUser Create(Guid id, long chatId, string userName, string firstName, string lastName) =>
            new(id, chatId, userName, firstName, lastName);
    }
}
