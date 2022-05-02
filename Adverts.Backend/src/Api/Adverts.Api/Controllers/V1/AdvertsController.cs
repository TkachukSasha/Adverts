using Adverts.Application.Common.Contracts;
using Adverts.Domain.Models.Request;
using Adverts.Domain.Models.Response;
using Adverts.Extensions.Common.AttributeExtensions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Adverts.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AdvertsController : Controller
    {
        private readonly IAdvertsRepository _repository;

        public AdvertsController(IAdvertsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("adverts")]
        [Cached(600)]
        public IActionResult GetAllAdverts()
        {
            var result = _repository.GetAllAdverts();
            return Ok(result);
        }

        [HttpGet("{name}")]
        public IActionResult GetAdvertByName(string name)
        {
            var result = _repository.GetAdvertByName(name);
            return Ok(result);
        }

        [HttpPost("advert")]
        public async Task<ActionResult<CreateAdvertResponse>> CreateAdvert([FromBody] CreateAdvertRequest request)
        {
            var result = await _repository.CreateAdvert(request);
            return Ok(result);
        }
    }
}
