using ErrorOr;
using MediatR;
using Modules.Auth.Domain.Users;

namespace Modules.Auth.Application.Users.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<ErrorOr<UserResponse>>
{
    public Guid UserId { get; }
    public GetUserByIdQuery(Guid userId)
    {
        UserId = userId;
    }
}
