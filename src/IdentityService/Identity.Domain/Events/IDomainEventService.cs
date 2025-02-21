﻿using Identity.Domain.Common;

namespace Identity.Domain.Events
{
    public interface IDomainEventService
    {
        Task PublishAsync(DomainEvent domainEvent);
        Task PublishAsync(IEnumerable<DomainEvent> domainEvents);
    }
}
