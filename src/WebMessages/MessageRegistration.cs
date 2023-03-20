using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using WebMessages.Foundation;

namespace WebMessages;

public class MessageRegistration : IMessageRegistration 
{
    private readonly IServiceCollection _serviceCollection;

    public MessageRegistration(IServiceCollection serviceCollection)
    {
        _serviceCollection = serviceCollection;
    }

    public void AddStorage<T>(Func<IServiceProvider, object>? func = null) where T : IMessagesStorage
    {
        if(func != null)
            _serviceCollection.TryAddSingleton(typeof(IMessagesStorage), func);
        else
            _serviceCollection.TryAddSingleton(typeof(IMessagesStorage), typeof(T));
    }

    public void AddProvider<T>() where T : IMessageProvider
    {
        _serviceCollection.TryAddSingleton(typeof(IMessageProvider), typeof(T));
    }
}