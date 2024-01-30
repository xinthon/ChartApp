using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SharedKhernel
{
    public interface IModuleInstaller
    {
        void InitializeModule(IServiceCollection services, IConfiguration configuration);
    }
}
