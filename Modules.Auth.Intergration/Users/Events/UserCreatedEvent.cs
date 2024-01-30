using MediatR;

namespace Modules.Auth.Intergration.Users.Events
{
    public class UserCreatedEvent : INotification
    {
        public Guid UserId { get; private set; }
        public UserCreatedEvent(Guid userId)
        {
            UserId = userId;
        }
    }
}
