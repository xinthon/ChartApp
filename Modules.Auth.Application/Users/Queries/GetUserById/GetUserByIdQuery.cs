using ErrorOr;
using MediatR;
using Modules.Auth.Domain.Users;

namespace Modules.Auth.Application.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<ErrorOr<UserResponse>>
{
    public UserId UserId { get; }
    public GetUserByIdQuery(UserId userId)
    {
        UserId = userId;
    }
}
