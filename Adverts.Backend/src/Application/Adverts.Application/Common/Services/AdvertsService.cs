using Adverts.Application.Common.Contracts;
using Adverts.Application.Common.Pagination.Filters;
using Adverts.Dal.Data;
using Adverts.Domain.Entities;
using Adverts.Domain.Models.Request;
using Adverts.Domain.Models.Response;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adverts.Application.Common.Services
{
    public class AdvertsService : IAdvertsRepository
    {
        private readonly AdvertsDbContext _context;
        private readonly IMapper _mapper;

        public AdvertsService(AdvertsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAdvertResponse> GetAllAdverts(PaginationFilter pagination)
        {
            var listOfAdverts = _context.Adverts.ToList();

            List<GetAdvertResponse> adverts = new List<GetAdvertResponse>();

            foreach (var advert in listOfAdverts)
            {
                var words = advert.PhotoUrl;

                if (words == null)
                {
                    var mapper = _mapper.Map<List<GetAdvertResponse>>(listOfAdverts);
                }

                string resultWord = words.Substring(0, words.IndexOf(','));

                var response = new GetAdvertResponse { AdvertName = advert.AdvertName, AdvertPrice = advert.AdvertPrice, PhotoUrl = resultWord };

                adverts.Add(response);
            }

            if (pagination == null)
            {
                return adverts;
            }

            var skip = (pagination.PageNumber - 1) * pagination.PageSize;

            return adverts.Skip(skip).Take(pagination.PageSize).ToList();
        }

        public GetAdvertResponse GetAdvertByName(string name)
        {
            var getAdvertByName = _context.Adverts.FirstOrDefault(a => a.AdvertName == name);

            var response = _mapper.Map<GetAdvertResponse>(getAdvertByName);

            return response;
        }

        public async Task<CreateAdvertResponse> CreateAdvert(CreateAdvertRequest request)
        {
            var advertId = Guid.NewGuid();

            var advert = new Advert
            {
                GID = advertId,
                AdvertName = request.AdvertName,
                AdvertDescription = request.AdvertDescription,
                AdvertPrice = request.AdvertPrice,
                PhotoUrl = request.PhotoUrl
            };

            await _context.Adverts.AddAsync(advert);
            await _context.SaveChangesAsync();

            var response = _mapper.Map<CreateAdvertResponse>(advert);

            return response;
        }
    }
}
