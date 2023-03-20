using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using WebMessages.Foundation;

namespace WebMessages.Storages.DistributedCacheStorage;

public class DistributedCacheService : IMessagesStorage
{   
    private readonly IDistributedCache _distributedCache;
    private readonly CacheOptions _options;

    public DistributedCacheService(IDistributedCache distributedCache, IOptions<CacheOptions> options)
    {
        _distributedCache = distributedCache;
        _options = options.Value;
    }
    
    private async Task StoreMessage(MessageTemplate message)
    {
        var messages = await GetMessages();
        messages.Add(message);
        await _distributedCache.SetStringAsync(_options.Key, JsonSerializer.Serialize(messages));
    }
    
    private async Task StoreMessages(IList<MessageTemplate> messages)
    {
        var _ = await GetMessages();
        _.AddRange(messages);
        await _distributedCache.SetStringAsync(_options.Key, JsonSerializer.Serialize(messages));
    }
    
    private async Task<List<MessageTemplate>> GetMessages()
    {
        var messages = await _distributedCache.GetStringAsync(_options.Key);
        
        if(string.IsNullOrEmpty(messages))
            return new List<MessageTemplate>();

        return JsonSerializer.Deserialize<List<MessageTemplate>>(messages) ?? new List<MessageTemplate>();
    }
    
    public Task AddMessageAsync(MessageTemplate message)
    {
        return StoreMessage(message);
    }

    public Task AddRangeMessageAsync(IList<MessageTemplate> messages)
    {
        return StoreMessages(messages);
    }

    public Task<List<MessageTemplate>> GetMessagesAsync() 
    {
        return GetMessages();
    }

    public void Clear()
    {
        _distributedCache.Remove(_options.Key);
    }
}