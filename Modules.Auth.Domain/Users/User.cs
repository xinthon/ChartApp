using Modules.Auth.Domain.Primitives;
using Modules.Auth.Domain.UserRoles;
using Modules.Auth.Domain.Users.Events;
using Modules.Auth.Domain.ValueObjects;

namespace Modules.Auth.Domain.Users
{
    public class User : Entity<UserId>
    {
        private List<UserRole> _userRoles = new List<UserRole>();
        private User(UserId id) : base(id)
        {
        }

        private User() : base(new UserId(Guid.NewGuid()))
        {
        }

        public Name Username { get; private set; } = Name.Empty;

        public Password Password { get; private set; } = Password.Empty;

        public Email Email { get; private set; } = Email.Empty;

        public IReadOnlyList<UserRole> UserRoles => _userRoles;

        public static User Create(Name username, Email email, Password password)
        {
            var user = new User() 
            { 
                Username = username, 
                Email = email, 
                Password = password 
            };
            user.AddDomainEvent(new UserCreatedDomainEvent(user.Id));

            return user;
        }

        public static User Update(UserId userId, Name username, Email email)
        {
            var user = new User(userId) { Username = username, Email = email };

            user.AddDomainEvent(new UserUpdatedDomainEvent(userId));

            return user;
        }

        public static User Delete(UserId userId)
        {
            var user = new User();
            user.AddDomainEvent(new UserDeletedDomainEvent(userId));
            return user;
        }
    }
}
