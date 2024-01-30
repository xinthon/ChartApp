using Modules.Auth.Domain.Roles;
using Modules.Auth.Domain.Users;

namespace Modules.Auth.Domain.UserRoles
{
    public class UserRole
    {
        private UserRole(UserId userId, RoleId roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        public UserId UserId { get; private set; }
        public User? User { get; private set; }

        public RoleId RoleId { get; private set; }
        public Role? Role { get; private set; }

        public static UserRole Create(UserId userId, RoleId roleId)
        {
            return new UserRole(userId, roleId);
        }
    }
}
