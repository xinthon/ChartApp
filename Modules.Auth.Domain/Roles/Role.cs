using Modules.Auth.Domain.Primitives;
using Modules.Auth.Domain.Roles.Events;
using Modules.Auth.Domain.UserRoles;
using Modules.Auth.Domain.ValueObjects;

namespace Modules.Auth.Domain.Roles
{
    public class Role : Entity<RoleId>
    {
        private readonly List<UserRole> _userRoles = new List<UserRole>();
        private Role(RoleId id, Name name) : base(id)
        {
            Name = name;
        }

        private Role() : base(new RoleId(Guid.NewGuid()))
        {
        }

        public Name Name { get; private set; } = Name.Empty;

        public IReadOnlyList<UserRole> UserRoles => _userRoles;

        public static Role Create(Name name)
        {
            var role = new Role()
            {
                Name = name
            };
            role.AddDomainEvent(new RoleCreatedDomainEvent(role.Id));

            return role;
        }

        public static Role Update(RoleId roleId, Name name)
        {
            var role = new Role(roleId, name);
            role.AddDomainEvent(new RoleUpdatedDomainEvent(roleId));
            return role;
        }

        public static Role Delete(RoleId roleId)
        {
            var role = new Role();
            role.AddDomainEvent(new RoleDeletedDomainEvent(roleId));
            return role;
        }
    }
}
