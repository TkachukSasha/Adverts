using System.Collections.Generic;

namespace Adverts.Domain.Models.Response
{
    public class GetAdvertResponse
    {
        public string AdvertName { get; set; }
        public IEnumerable<string> PhotosUrl { get; set; }
        public decimal AdvertPrice { get; set; }
    }
}
