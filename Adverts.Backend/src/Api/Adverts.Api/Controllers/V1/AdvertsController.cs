using Adverts.Application.Common.Contracts;
using Adverts.Application.Common.Pagination.Filters;
using Adverts.Application.Common.Pagination.Helpers;
using Adverts.Application.Common.Pagination.Queries;
using Adverts.Application.Common.Pagination.Response;
using Adverts.Domain.Models.Request;
using Adverts.Domain.Models.Response;
using Adverts.Extensions.Common.AttributeExtensions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Adverts.Api.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AdvertsController : Controller
    {
        private readonly IAdvertsRepository _repository;
        private readonly IMapper _mapper;
        private readonly IUriRepository _uriService;

        public AdvertsController(IAdvertsRepository repository, IMapper mapper, IUriRepository uriService)
        {
            _repository = repository;
            _mapper = mapper;
            _uriService = uriService; 
        }

        [HttpGet("adverts")]
        [Cached(600)]
        public IActionResult GetAllAdverts([FromQuery] PaginationQuery query)
        {
            var pagginationQuery = _mapper.Map<PaginationFilter>(query);
            var result = _repository.GetAllAdverts(pagginationQuery);

            if (pagginationQuery == null || pagginationQuery.PageNumber < 1 || pagginationQuery.PageSize < 1)
            {
                return Ok(new PagedResponse<GetAdvertResponse>(result));
            }

            var response = PaginationHelper.CreatePaginatedResponse(_uriService, pagginationQuery, result);

            return Ok(response);
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
