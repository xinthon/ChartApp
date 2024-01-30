using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SharedKhernel.Extensions;

public static class ModuleInstallerExtension
{
    public static IServiceCollection AddModule<TModuleInstaller>(
        this IServiceCollection services,
        IConfiguration configuration)
        where TModuleInstaller : IModuleInstaller, new()
    {
        var moduleInstaller = new TModuleInstaller();
        moduleInstaller.InitializeModule(services, configuration);

        return services;
    }
}
