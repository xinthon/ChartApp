using Modules.Auth.Application.Abstractions;
using Modules.Auth.Infrastructure.Persistence.Data;

namespace Modules.Auth.Infrastructure;

internal class UnitOfWork : IUnitOfWork
{
    private readonly AuthDbContext _dbContext;
    public UnitOfWork(AuthDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
