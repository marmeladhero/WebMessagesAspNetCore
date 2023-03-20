using System.Linq.Expressions;
using Microsoft.AspNetCore.Http;
using WebMessages.Foundation;

namespace WebMessages;

public class MessagesService : IWebMessages
{
    private readonly IMessagesStorage _messagesStorage;
    private readonly IMessageProvider _provider;
    private readonly IHttpContextAccessor _accessor;

    public MessagesService(IMessagesStorage messagesStorage, IMessageProvider provider, IHttpContextAccessor accessor)
    {
        _messagesStorage = messagesStorage;
        _provider = provider;
        _accessor = accessor;
    }

    private bool SaveToAnotherRequest(MessageTemplate messageTemplate)
    {
        if(messageTemplate.Options.DeleteAfterRead)
            return false;
        
        if(messageTemplate.Options.ExpirationDate != null && messageTemplate.Options.ExpirationDate < DateTime.Now)
            return false;
        
        return true;
    }
    private bool CanShow(MessageTemplate messageTemplate)
    {
        var request = _accessor.HttpContext?.Request;
        if (request != null)
        {
            if (messageTemplate.Options.Path != null && !request.Path.StartsWithSegments(messageTemplate.Options.Path))
                return false;
        }
        
        if(messageTemplate.Options.ExpirationDate != null && messageTemplate.Options.ExpirationDate < DateTime.Now)
            return false;
        
        return true;
    }
    
    public Task AddMessageAsync(MessageTemplate message) 
    {
        return _messagesStorage.AddMessageAsync(message);
    }

    public async Task<IEnumerable<string>> MessagesAsync()
    {
        var messages = await _messagesStorage.GetMessagesAsync();
        
        var messageTemplates = messages.Where(CanShow).ToList();
        
        var saveMessages  = messages.Where(SaveToAnotherRequest).ToList();
        
        _messagesStorage.Clear();
        
        await _messagesStorage.AddRangeMessageAsync(saveMessages);
        
        return messageTemplates.Select(m => _provider.Render(m));
    }
    
    
}