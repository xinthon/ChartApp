using MediatR;

namespace Modules.Auth.Intergration.Users.Events
{
    public class UserUpdatedEvent : INotification
    {
        public Guid UserId { get; private set; }
        public UserUpdatedEvent(Guid userId)
        {
            UserId = userId;
        }
    }
}
