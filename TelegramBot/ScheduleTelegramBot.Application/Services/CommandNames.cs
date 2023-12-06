using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTelegramBot.Application.Services
{
    public class CommandNames
    {
        public const string StartCommand = "/start";
        public const string AddOperationCommand = "add-operation";
        public const string FinishOperationCommand = "finish-operation";
        public const string SelectCategoryCommand = "select-category";
        public const string GetTomorrowTasks = "get-tomorrow-tasks";
        public const string GetNextWeekTasks = "get-next-week-tasks";
        public const string GetNextMonthTasks = "get-next-month-tasks";
        public const string GetAllTasks = "get-all-tasks";
    }
}
