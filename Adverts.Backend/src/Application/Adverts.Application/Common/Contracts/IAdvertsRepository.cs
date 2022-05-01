using Adverts.Domain.Models.Request;
using Adverts.Domain.Models.Response;
using System.Threading.Tasks;

namespace Adverts.Application.Common.Contracts
{
    public interface IAdvertsRepository
    {
        GetAdvertResponse GetAllAdverts();
        GetAdvertResponse GetAdvertByName(string name);
        Task<CreateAdvertResponse> CreateAdvert(CreateAdvertRequest request);
    }
}
