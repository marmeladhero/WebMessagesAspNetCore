namespace WebMessages.Storages.DistributedCacheStorage;

public class CacheOptions
{
    public string Key { get; set; } = Guid.NewGuid().ToString();
}