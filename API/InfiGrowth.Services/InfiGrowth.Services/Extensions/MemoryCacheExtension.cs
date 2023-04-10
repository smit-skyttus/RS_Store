using Microsoft.Extensions.Caching.Memory;

namespace InfiGrowth.Services.Extensions
{
    public static class MemoryCacheExtension
    {
        public static MemoryCacheEntryOptions GetMemoryCacheOptions()
        {
            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(50),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(20)
            };
            return cacheExpiryOptions;
        }
    }
}
