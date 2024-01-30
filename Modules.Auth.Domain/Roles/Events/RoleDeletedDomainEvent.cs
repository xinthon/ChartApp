using Modules.Auth.Domain.Primitives;

namespace Modules.Auth.Domain.Roles.Events;

internal class RoleDeletedDomainEvent : IDomainEvent
{
    public RoleId RoleId { get; private set; }
    public RoleDeletedDomainEvent(RoleId roleId)
    {
        RoleId = roleId;
    }
}
