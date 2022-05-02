using Adverts.Application.Common.Pagination.Queries;
using System;

namespace Adverts.Application.Common.Contracts
{
    public interface IUriRepository
    {
        Uri GetAllAdvertsUri(PaginationQuery query = null);
    }
}
