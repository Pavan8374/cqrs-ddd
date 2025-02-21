using MediatR;

namespace Identity.Domain.Common
{
    public abstract class DomainEvent : INotification
    {
        public DateTime OccurredOn { get; }
        public Guid Id { get; }

        protected DomainEvent()
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
        }
    }
}
