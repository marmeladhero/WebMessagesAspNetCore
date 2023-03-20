using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using WebMessages.Foundation;

namespace WebMessages.Storages.DistributedCacheStorage;

public static class RegisterServices
{
    
    public static IMessageRegistration AddDistributedCacheStorage(this IMessageRegistration registration, Action<CacheOptions> options)
    {
        var opt = new CacheOptions();
        options(opt);
        registration.AddStorage<DistributedCacheService>(x => new DistributedCacheService(x.GetRequiredService<IDistributedCache>(), Options.Create(opt)));
        return registration;
    }
}