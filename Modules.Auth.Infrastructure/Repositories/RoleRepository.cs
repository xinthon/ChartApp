using Modules.Auth.Application.Abstractions.Repositories;
using Modules.Auth.Domain.Roles;

namespace Modules.Auth.Infrastructure.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        public Task<Role> GetByIdAsync(RoleId roleId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
