using ErrorOr;
using MediatR;
using Modules.Auth.Domain.Users;

namespace Modules.Auth.Application.Users.Commands.Delete
{
    public class DeleteUserCommand : IRequest<ErrorOr<UserId>>
    {
        public DeleteUserCommand(UserId userId)
        {
            UserId = userId;
        }

        public UserId UserId { get; private set; }
    }
}
