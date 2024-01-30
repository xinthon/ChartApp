using Modules.Auth.Domain.Primitives;

namespace Modules.Auth.Domain.Roles.Events;

internal class RoleCreatedDomainEvent : IDomainEvent
{
    public RoleId RoleId { get; private set; }
    public RoleCreatedDomainEvent(RoleId roleId)
    {
        RoleId = roleId;
    }
}
