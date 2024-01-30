using ErrorOr;
using MediatR;
using Modules.Auth.Domain.Users;

namespace Modules.Auth.Application.Users.Commands.Update
{
    public class UpdateUserCommand : IRequest<ErrorOr<UserId>>
    {
        public UpdateUserCommand(UserId userId, string username, string email, string password)
        {
            UserId = userId;
            Username = username;
            Email = email;
            Password = password;
        }
        public UserId UserId { get; private set; }
        public string Username { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }
    }
}
