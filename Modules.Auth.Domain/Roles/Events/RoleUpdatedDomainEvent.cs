
using Modules.Auth.Domain.Primitives;

namespace Modules.Auth.Domain.Roles.Events;

internal class RoleUpdatedDomainEvent : IDomainEvent
{
    public RoleId RoleId { get; private set; }
    public RoleUpdatedDomainEvent(RoleId roleId)
    {
        RoleId = roleId;
    }
}
