using System;
using System.Threading.Tasks;

namespace Adverts.Application.Common.Contracts
{
    public interface ICacheRepository
    {
        Task CacheResponseAsync(string cacheKey, object response, TimeSpan timeLive);
        Task<string> GetCachedResponseAsync(string cacheKey);
    }
}
