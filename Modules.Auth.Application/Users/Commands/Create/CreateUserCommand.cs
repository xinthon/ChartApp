using ErrorOr;
using MediatR;
using Modules.Auth.Domain.Users;

namespace Modules.Auth.Application.Users.Commands.Create
{
    public class CreateUserCommand : IRequest<ErrorOr<UserId>>
    {
        public CreateUserCommand(string username, string email, string password)
        {
            Username = username;
            Email = email;
            Password = password;
        }

        public string Username { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }
    }
}
