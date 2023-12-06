using Microsoft.Extensions.Configuration;
using ScheduleTelegramBot.Application.Services;
using Telegram.Bot;

namespace ScheduleTelegramBot.Infrastructure.Services
{
    public class TelegramBotService : ITelegramBotClientService
    {
        private readonly IConfiguration _configuration;
        private TelegramBotClient _botClient;

        public TelegramBotService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<TelegramBotClient> GetBot()
        {
            if(_botClient is not null)
            {
                return _botClient;
            }

            _botClient = new TelegramBotClient(_configuration["Token"]);

            return _botClient;
        }
    }
}
