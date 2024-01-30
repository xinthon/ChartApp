using Modules.Auth.Domain.Roles;
using Modules.Auth.Domain.Users;

namespace Modules.Auth.Application.Abstractions.Repositories;

public interface IRoleRepository
{
    Task<Role> GetByIdAsync(RoleId roleId, CancellationToken cancellationToken = default);
}
