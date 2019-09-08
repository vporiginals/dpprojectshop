using System;

namespace Shopee.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        ShopeeDbContext Init();
    }
}