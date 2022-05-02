using Adverts.Application.Common.Pagination.Filters;
using Adverts.Domain.Models.Request;
using Adverts.Domain.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adverts.Application.Common.Contracts
{
    public interface IAdvertsRepository
    {
        List<GetAdvertResponse> GetAllAdverts(PaginationFilter pagination = null);
        GetAdvertResponse GetAdvertByName(string name);
        Task<CreateAdvertResponse> CreateAdvert(CreateAdvertRequest request);
    }
}
