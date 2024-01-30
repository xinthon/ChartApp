using Modules.Auth.Domain.Primitives;

namespace Modules.Auth.Domain.Users.Events
{
    public class UserUpdatedDomainEvent : IDomainEvent
    {
        public UserId UserId { get; }
        public UserUpdatedDomainEvent(UserId userId)
        {
            UserId = userId;
        }
    }
}
