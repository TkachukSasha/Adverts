using Adverts.Application.Common.Contracts;
using Adverts.Dal.Data;
using Adverts.Domain.Entities;
using Adverts.Domain.Models.Request;
using Adverts.Domain.Models.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public List<GetAdvertResponse> GetAllAdverts()
        {
            var listOfAdverts = _context.Adverts.ToList();

            var mapper = _mapper.Map<List<GetAdvertResponse>>(listOfAdverts);

            return mapper;
        }

        public GetAdvertResponse GetAdvertByName(string name)
        {
            var getAdvertByName = _context.Adverts.FirstOrDefault(a => a.AdvertName == name);

            var mapper = _mapper.Map<GetAdvertResponse>(getAdvertByName);

            return mapper;
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

            var mapper = _mapper.Map<CreateAdvertResponse>(advert);

            return mapper;
        }
    }
}
