namespace Modules.Auth.Domain.Roles;

public class RoleId
{
    public Guid Value { get; }

    public RoleId(Guid value) { Value = value; }

    public RoleId() { Value = Guid.NewGuid(); }
}
