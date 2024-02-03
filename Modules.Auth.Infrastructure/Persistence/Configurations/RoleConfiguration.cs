using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Auth.Domain.Roles;
using Modules.Auth.Domain.ValueObjects;

namespace Modules.Auth.Infrastructure.Persistence.Configurations
{
    internal class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .HasConversion(p => p.Value, value => new RoleId(value));

            builder.Property(x => x.Name)
                .HasConversion(x => x.Value, value => Name.Create(value))
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
