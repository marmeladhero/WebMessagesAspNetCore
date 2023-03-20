namespace WebMessages.Foundation;

public interface IMessageRegistration
{
    void AddStorage<T>(Func<IServiceProvider, object>? func = null) where T : IMessagesStorage;
    void AddProvider<T>() where T : IMessageProvider;
}