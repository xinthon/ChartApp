using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Modules.Auth.Domain.Users;
using Modules.Auth.Domain.ValueObjects;

namespace Modules.Auth.Infrastructure.Persistence.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .Property(x => x.Id)
                .HasConversion(id => id.Value, value => new UserId(value));

            builder.Property(x => x.Username)
                .HasConversion(x => x.Value, value => Name.Create(value))
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Email)
                .HasConversion(email => email.Value, value => Email.Create(value))
                .IsRequired()
                .HasMaxLength(50);

            builder.OwnsOne(x => x.Password, builder =>
            {
                builder.Property(p => p.PasswordSalt);
                builder.Property(p => p.PasswordHash);
            });
        }
    }
}
