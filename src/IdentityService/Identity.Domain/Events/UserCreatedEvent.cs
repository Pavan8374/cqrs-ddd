using Identity.Domain.Common;

namespace Identity.Domain.Events
{
    public class UserCreatedEvent : DomainEvent
    {
        public Guid UserId { get; }
        public string Email { get; }

        public UserCreatedEvent(Guid userId, string email)
        {
            UserId = userId;
            Email = email;
        }
    }
}
