using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ScheduleTelegramBot.Application.Services
{
    public interface ICommandExecutor
    {
        Task Execute(Update update);
    }
}
