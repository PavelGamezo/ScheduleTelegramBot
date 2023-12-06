using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleTelegramBot.Domain.Common.Domain
{
    public abstract class BaseEntity : IEquatable<BaseEntity>
    {
        public Guid Id { get; init; }

        public IEnumerable<IDomainEvents> Events => _domainEvents;

        private readonly List<IDomainEvents> _domainEvents = new();

        protected BaseEntity(Guid id)
        {
            Id = id;
        }

        public void AddDomainEvent(IDomainEvents domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(IDomainEvents domainEvent)
        {
            _domainEvents.Remove(domainEvent);
        }

        public void ClearDomainEvents() => 
            _domainEvents.Clear();

        public override bool Equals(object? obj)
        {
            if (obj is null || obj.GetType() != GetType() || obj is not BaseEntity entity)
            {
                return false;
            }

            return entity.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public bool Equals(BaseEntity? other)
        {
            if (other is null || other.GetType() != GetType())
            {
                return false;
            }

            return other.Id == Id;
        }

        public static bool operator ==(BaseEntity? first, BaseEntity? second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(BaseEntity? first, BaseEntity? second)
        {
            return !(first == second);
        }
    }
}
