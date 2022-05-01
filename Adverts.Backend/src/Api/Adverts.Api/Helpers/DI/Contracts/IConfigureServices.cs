using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adverts.Api.Helpers.DI.Contracts
{
    public interface IConfigureServices
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
