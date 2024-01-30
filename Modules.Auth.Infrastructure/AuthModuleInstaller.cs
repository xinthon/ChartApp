using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Auth.Application;
using Modules.Auth.Application.Abstractions;
using Modules.Auth.Application.Abstractions.Repositories;
using Modules.Auth.Infrastructure.Interceptors;
using Modules.Auth.Infrastructure.Persistence.Data;
using Modules.Auth.Infrastructure.Repositories;
using SharedKhernel;

namespace Modules.Auth.Infrastructure;

public class AuthModuleInstaller : IModuleInstaller
{
    public void InitializeModule(IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplication(configuration);
        services.AddApplication(configuration);

        services.AddDbContext<AuthDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("Database"), builder => 
            {
                builder.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "auth");
                builder.MigrationsAssembly("Modules.Auth.Infrastructure"); 
            });
        });

        services.AddSingleton<PublishDomainEventInterceptor>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
    }
}
