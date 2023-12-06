using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTelegramBot.Domain.AppUser.Factories
{
    public interface IAppUserFactory
    {
        Entities.AppUser Create(
            Guid id,
            long chatId,
            string userName,
            string firstName,
            string lastName);
    }
}
