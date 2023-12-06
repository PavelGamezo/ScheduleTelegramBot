using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace ScheduleTelegramBot.Application.Services
{
    public interface ITelegramBotClientService
    {
        Task<TelegramBotClient> GetBot();
    }
}
