using Adverts.Api.Helpers.DI.Contracts;
using Adverts.Application.Common.Contracts;
using Adverts.Application.Common.Services;
using Adverts.Dal.DI;
using Adverts.Extensions.Common.Helpers.Mapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Adverts.Api.Helpers.DI.Services
{
    public class ApplicationServices : IConfigureServices
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAdvertsRepository, AdvertsService>();
            services.AddPersistence(configuration);
            services.AddAutoMapper(typeof(AdvertsProfile));
        }
    }
}
