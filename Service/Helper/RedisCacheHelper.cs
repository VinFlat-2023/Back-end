using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Caching.Distributed;
using Service.IHelper;

namespace Service.Helper;

public class RedisCacheHelper : IRedisCacheHelper
{
    private readonly IDistributedCache _redis;

    public RedisCacheHelper(IDistributedCache redis)
    {
        _redis = redis;
    }

    public async Task<T?> GetCacheDataAsync<T>(string cacheKey)
    {
        // Get cache data using cache key
        var cacheData = await _redis.GetStringAsync(cacheKey);

        // Check if the cache data response contains data
        return !string.IsNullOrEmpty(cacheData)
            ?
            // It did, let's deserialize it and return it
            JsonSerializer.Deserialize<T>(cacheData)
            :
            // We did not get any data return T
            default;
    }

    public async Task<TPageList?> GetCachePagedDataAsync<TPageList>(string cacheKey)
    {
        var cacheData = await _redis.GetStringAsync(cacheKey);


        // Check if the cache data response contains data
        try
        {
            if (!string.IsNullOrEmpty(cacheData))
                // It did, let's deserialize it and return it
                return JsonSerializer.Deserialize<TPageList>(cacheData);

            // failed to deserialize, remove cache to avoid future errors
        }
        catch
        {
            await _redis.RemoveAsync(cacheKey);
        }

        // We did not get any data return T
        return default;
    }

    public async Task RemoveCacheDataAsync(string cacheKey)
    {
        // Remove the cache data
        await _redis.RemoveAsync(cacheKey);
    }

    public async Task SetCacheDataAsync<T>(string cacheKey, T cacheValue, double absExpRelToNow,
        double slidingExpiration)
    {
        // Configure cache expiration
        var cacheExpiry = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(absExpRelToNow),
            SlidingExpiration = TimeSpan.FromMinutes(slidingExpiration)
        };
        JsonSerializerOptions options = new()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };


        // Set the cache
        await _redis.SetStringAsync(cacheKey, JsonSerializer.Serialize(cacheValue, options), cacheExpiry);
    }
}