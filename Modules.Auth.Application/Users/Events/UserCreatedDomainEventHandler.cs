using MediatR;
using Modules.Auth.Domain.Users.Events;
using Modules.Auth.Intergration.Users.Events;

namespace Modules.Auth.Application.Users.Events
{
    public class UserCreatedDomainEventHandler : INotificationHandler<UserCreatedDomainEvent>
    {
        private readonly IPublisher _publisher;
        public UserCreatedDomainEventHandler(IPublisher publisher)
        {
            _publisher = publisher;
        }

        public async Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _publisher.Publish(new UserCreatedEvent(notification.UserId.Value), cancellationToken);
        }
    }
}
