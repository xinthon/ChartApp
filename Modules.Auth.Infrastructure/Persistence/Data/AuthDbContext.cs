using Microsoft.EntityFrameworkCore;
using Modules.Auth.Domain.Primitives;
using Modules.Auth.Domain.Roles;
using Modules.Auth.Domain.UserRoles;
using Modules.Auth.Domain.Users;
using Modules.Auth.Infrastructure.Interceptors;

namespace Modules.Auth.Infrastructure.Persistence.Data
{
    public class AuthDbContext : DbContext
    {
        private readonly PublishDomainEventInterceptor _publishDomainEventInterceptor;

        public AuthDbContext(
            DbContextOptions<AuthDbContext> options,
            PublishDomainEventInterceptor publishDomainEventInterceptor) : base(options)
        { _publishDomainEventInterceptor = publishDomainEventInterceptor; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_publishDomainEventInterceptor);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("auth");

            modelBuilder
                .Ignore<List<IDomainEvent>>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthDbContext).Assembly);
        }


        public DbSet<User> Users => Set<User>();

        public DbSet<Role> Roles => Set<Role>();

        public DbSet<UserRole> UserRoles => Set<UserRole>();
    }
}
