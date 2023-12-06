using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTelegramBot.Domain.Common.Domain
{
    public abstract class AggregateRoot : BaseEntity
    {
        public AggregateRoot(Guid id) : base(id) 
        { 
        }
    }
}
