using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Auth.Domain.Roles;
using Modules.Auth.Domain.UserRoles;
using Modules.Auth.Domain.Users;

namespace Modules.Auth.Infrastructure.Persistence.Configurations
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(gm => new { gm.RoleId, gm.UserId });

            builder.Property(x => x.UserId)
                .HasConversion(
                    entity => entity.Value,
                    value => new UserId(value));

            builder.Property(x => x.RoleId)
                .HasConversion(
                    entity => entity.Value,
                    value => new RoleId(value));

            builder.HasOne(gm => gm.Role)
                .WithMany(x => x.UserRoles)
                .HasForeignKey(gm => gm.RoleId);

            builder.HasOne(gm => gm.User)
                .WithMany(gm => gm.UserRoles)
                .HasForeignKey(gm => gm.UserId);
        }
    }
}
