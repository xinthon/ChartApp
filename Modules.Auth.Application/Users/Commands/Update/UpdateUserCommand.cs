using ErrorOr;
using MediatR;
using Modules.Auth.Domain.Users;

namespace Modules.Auth.Application.Users.Commands.Update
{
    public class UpdateUserCommand : IRequest<ErrorOr<UserId>>
    {
        public UpdateUserCommand(Guid userId, string username, string email)
        {
            UserId = userId;
            Username = username;
            Email = email;
        }
        public Guid UserId { get; private set; }

        public string Username { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }
    }
}
