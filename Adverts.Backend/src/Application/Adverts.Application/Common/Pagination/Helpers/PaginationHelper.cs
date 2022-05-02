using Adverts.Application.Common.Contracts;
using Adverts.Application.Common.Pagination.Filters;
using Adverts.Application.Common.Pagination.Queries;
using Adverts.Application.Common.Pagination.Response;
using System.Collections.Generic;
using System.Linq;

namespace Adverts.Application.Common.Pagination.Helpers
{
    public class PaginationHelper
    {
        public static object CreatePaginatedResponse<T>(IUriRepository uriService, PaginationFilter paginationFilter, List<T> adverts)
        {
            var nextPage = paginationFilter.PageNumber >= 1 ? uriService
                .GetAllAdvertsUri(new PaginationQuery(paginationFilter.PageNumber + 1, paginationFilter.PageSize)).ToString() : null;

            var previousPage = paginationFilter.PageNumber - 1 >= 1 ? uriService
                .GetAllAdvertsUri(new PaginationQuery(paginationFilter.PageNumber - 1, paginationFilter.PageSize)).ToString() : null;

            return new PagedResponse<T>
            {
                Data = adverts,
                PageNumber = (int)(paginationFilter.PageNumber >= 1 ? paginationFilter.PageNumber : (int?)null),
                PageSize = (int)(paginationFilter.PageSize >= 1 ? paginationFilter.PageSize : (int?)null),
                NextPage = adverts.Any() ? nextPage : null,
                PreviousPage = previousPage
            };
        }
    }
}
