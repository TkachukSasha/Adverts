using Adverts.Domain.Entities;
using Adverts.Domain.Models.Request;
using Adverts.Domain.Models.Response;
using AutoMapper;

namespace Adverts.Extensions.Common.Helpers.Mapper
{
    public class AdvertsProfile : Profile
    {
        public AdvertsProfile()
        {
            CreateMap<CreateAdvertRequest, Advert>().ReverseMap();
            CreateMap<Advert, GetAdvertResponse>().ReverseMap();
            CreateMap<Advert, CreateAdvertResponse>().ReverseMap();
        }
    }
}
