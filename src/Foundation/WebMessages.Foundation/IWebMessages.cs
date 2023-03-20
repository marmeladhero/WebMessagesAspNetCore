namespace WebMessages.Foundation;

public interface IWebMessages
{
    Task AddMessageAsync(MessageTemplate message);
    Task<IEnumerable<string>> MessagesAsync();
}