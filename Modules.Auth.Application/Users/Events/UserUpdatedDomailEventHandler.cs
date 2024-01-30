using MediatR;
using Modules.Auth.Domain.Users.Events;
using Modules.Auth.Intergration.Users.Events;

namespace Modules.Auth.Application.Users.Events;

public class UserUpdatedDomailEventHandler : INotificationHandler<UserUpdatedDomainEvent>
{
    private readonly IPublisher _publisher;
    public UserUpdatedDomailEventHandler(IPublisher publisher)
    {
        _publisher = publisher;
    }

    public async Task Handle(UserUpdatedDomainEvent notification, CancellationToken cancellationToken)
    {
        await _publisher.Publish(new UserUpdatedEvent(notification.UserId.Value), cancellationToken);
    }
}
