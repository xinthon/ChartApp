using Modules.Auth.Domain.Primitives;

namespace Modules.Auth.Domain.Users.Events
{
    public class UserDeletedDomainEvent : IDomainEvent
    {
        public UserId UserId { get; private set; }
        public UserDeletedDomainEvent(UserId userId)
        {
            UserId = userId;
        }
    }
}
