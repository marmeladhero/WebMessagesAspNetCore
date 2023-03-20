namespace WebMessages.Foundation;

public interface IMessagesStorage
{
    Task AddMessageAsync(MessageTemplate message);
    Task AddRangeMessageAsync(IList<MessageTemplate> messages);
    Task<List<MessageTemplate>> GetMessagesAsync();
    void Clear();
}