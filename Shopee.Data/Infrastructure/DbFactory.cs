namespace Shopee.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private ShopeeDbContext dbContext;

        public ShopeeDbContext Init()
        {
            return dbContext ?? (dbContext = new ShopeeDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}