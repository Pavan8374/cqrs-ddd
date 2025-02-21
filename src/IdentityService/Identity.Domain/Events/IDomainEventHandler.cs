using Identity.Domain.Common;
using MediatR;

namespace Identity.Domain.Events
{
    public interface IDomainEventHandler<in TEvent> : INotificationHandler<TEvent>
        where TEvent : DomainEvent
    {
    }
}
