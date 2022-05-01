using System.Collections.Generic;

namespace Adverts.Domain.Models.Request
{
    public class CreateAdvertRequest
    {
        public string AdvertName { get; set; }
        public string AdvertDescription { get; set; }
        public decimal AdvertPrice { get; set; }
        public string PhotoUrl { get; set; }
    }
}
