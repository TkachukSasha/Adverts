using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Adverts.Domain.Entities
{
    public class Advert : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string AdvertName { get; set; }

        [Required]
        [MaxLength(1000)]
        public string AdvertDescription { get; set; }

        public decimal AdvertPrice { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;

        [Required]
        [Range(0, 3)]
        public IEnumerable<string> PhotosUrl { get; set; }
    }
}
