using ErrorOr;
using MediatR;
using Modules.Auth.Application.Abstractions.Repositories;

namespace Modules.Auth.Application.Users.Queries.GetUsers;

public sealed class GetUsersQueryHanlder : IRequestHandler<GetUsersQuery, ErrorOr<IEnumerable<UserResponse>>>
{
    private readonly IUserRepository _userRepository;
    public GetUsersQueryHanlder(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<IEnumerable<UserResponse>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        if(users == null)
            return Error.NotFound(nameof(users));

        return users.Select(UserResponse.FromUser).ToArray();
    }
}
