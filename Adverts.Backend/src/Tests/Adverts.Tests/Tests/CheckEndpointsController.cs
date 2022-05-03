using Adverts.Tests.Settings;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Adverts.Tests.Tests
{
    public class CheckEndpointsController : IClassFixture<AppInstance>
    {
        private readonly AppInstance _appInstance;

        public CheckEndpointsController(AppInstance appInstance)
        {
            _appInstance = appInstance;
        }

        [Fact]
        public async Task CheckAdvertsEndpoint_ShouldReturnOk()
        {
            var client = _appInstance.CreateClient(new()
            {
                AllowAutoRedirect = false,
            });
            var result = await client.GetAsync("api/v1/adverts/adverts");
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task CheckAdvertByNameEndpoint_ShouldReturnOk()
        {
            var client = _appInstance.CreateClient(new()
            {
                AllowAutoRedirect = false,
            });
            var result = await client.GetAsync("api/v1/adverts/{name}");
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }

        [Fact]
        public async Task CheckCreateAdvertEndpoint_ShouldReturnOk()
        {
            var client = _appInstance.CreateClient(new()
            {
                AllowAutoRedirect = false,
            });
            var result = await client.PostAsync("api/v1/adverts/advert", null);
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
