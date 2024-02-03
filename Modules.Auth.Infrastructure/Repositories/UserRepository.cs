using Microsoft.EntityFrameworkCore;
using Modules.Auth.Application.Abstractions.Repositories;
using Modules.Auth.Domain.Users;
using Modules.Auth.Infrastructure.Persistence.Data;

namespace Modules.Auth.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly AuthDbContext _dbContext;
        public UserRepository(AuthDbContext dbContext) { _dbContext = dbContext; }

        public async Task<UserId> CreateAsync(User user, CancellationToken cancellationToken = default)
        {
            await _dbContext
                .Users
                .AddAsync(user, cancellationToken);
            return user.Id;
        }

        public async Task<UserId> DeleteAsync(UserId userId, CancellationToken cancellationToken = default)
        {
            await _dbContext
                .Users
                .Where(u => u.Id == userId)
                .ExecuteDeleteAsync(cancellationToken);

            return userId;
        }

        public async Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext
                .Users
                .Include(u => u.UserRoles)
                .ToListAsync(cancellationToken);
        }

        public async Task<User> GetByIdAsync(UserId userId, CancellationToken cancellationToken = default)
        {
            return await _dbContext
                .Users
                .Include(u => u.UserRoles)
                .SingleAsync(u => u.Id == userId, cancellationToken);
        }

        public async Task<UserId> UpdateAsync(User user, CancellationToken cancellationToken = default)
        {
            await _dbContext.Users.Where(u => u.Id == user.Id)
                .ExecuteUpdateAsync(u => u
                    .SetProperty(p => p.Username, user.Username)
                    .SetProperty(p => p.Email, user.Email));

            return user.Id;
        }
    }
}
