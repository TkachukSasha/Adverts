using System.Collections.Generic;

namespace Adverts.Domain.Models.Response
{
    public class GetAdvertResponse
    {
        public string AdvertName { get; set; }
        public string PhotoUrl { get; set; }
        public decimal AdvertPrice { get; set; }
    }
}
