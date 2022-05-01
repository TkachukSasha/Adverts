using System;
using System.ComponentModel.DataAnnotations;

namespace Adverts.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid GID { get; set; }
    }
}
