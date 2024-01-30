using ErrorOr;
using MediatR;
using Modules.Auth.Application.Abstractions.Repositories;

namespace Modules.Auth.Application.Users.Queries.GetUserById;

internal class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, ErrorOr<UserResponse>>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository) { _userRepository = userRepository; }

    public async Task<ErrorOr<UserResponse>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellationToken);
        if(user is null)
        {
            return Error.NotFound(nameof(user));
        }

        var userResponse = UserResponse.FromUser(user);

        var userRoles = user.UserRoles.Select(ur => ur.Role!.Name).ToArray();
        foreach(var role in userRoles)
        {
            userResponse.Roles.Add(role);
        }
        return userResponse;
    }
}
