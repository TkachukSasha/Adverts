namespace Adverts.Dal.Data
{
    public class DataInitializer
    {
        public static void Initialize(AdvertsDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
