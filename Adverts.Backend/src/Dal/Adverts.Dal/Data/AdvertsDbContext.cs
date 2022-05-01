using Adverts.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Adverts.Dal.Data
{
    public class AdvertsDbContext : DbContext
    {
        public AdvertsDbContext(DbContextOptions<AdvertsDbContext> options) : base(options)
        {
        }

        public DbSet<Advert> Adverts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
