using Modules.Auth.Domain.Users;

namespace Modules.Auth.Application.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<UserId> CreateAsync(User user, CancellationToken cancellationToken = default);
        Task<UserId> UpdateAsync(User user, CancellationToken cancellationToken = default);
        Task<UserId> DeleteAsync(UserId user, CancellationToken cancellationToken = default);
        Task<User> GetByIdAsync(UserId userId, CancellationToken cancellationToken = default);
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
