using Modules.Auth.Domain.Primitives;

namespace Modules.Auth.Domain.Users.Events
{
    public class UserCreatedDomainEvent : IDomainEvent
    {
        public UserId UserId { get; }
        public UserCreatedDomainEvent(UserId userId)
        {
            UserId = userId;
        }
    }
}
