namespace WebMessages.Foundation;

public class MessageTemplate : IMessage
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string Message { get; set; } = null!;
    public MessageType Type { get; set; }
    public MessageOption Options { get; set; } = new MessageOption();
    
    public MessageTemplate()
    {
        Id = Guid.NewGuid();
    }
    
    public MessageTemplate(string message, MessageType type)
    {
        Id = Guid.NewGuid();
        Message = message;
        Type = type;
    }
    
    public MessageTemplate(string message, MessageType type, MessageOption option)
    {
        Id = Guid.NewGuid();
        Message = message;
        Type = type;
        Options = option;
    }
    
    public MessageTemplate(string title, string message, MessageType type)
    {
        Id = Guid.NewGuid();
        Title = title;
        Message = message;
        Type = type;
    }
    
    public MessageTemplate(string title, string message, MessageType type, MessageOption option)
    {
        Id = Guid.NewGuid();
        Title = title;
        Message = message;
        Type = type;
        Options = option;
    }
    
    public MessageTemplate(Guid id, string message, MessageType type)
    {
        Id = id;
        Message = message;
        Type = type;
    }
    
    public MessageTemplate(Guid id, string message, MessageType type, MessageOption option)
    {
        Id = id;
        Message = message;
        Type = type;
        Options = option;
    }
    
    public MessageTemplate(Guid id, string title, string message, MessageType type)
    {
        Id = id;
        Title = title;
        Message = message;
        Type = type;
    }
    
    public MessageTemplate(Guid id, string title, string message, MessageType type, MessageOption option)
    {
        Id = id;
        Title = title;
        Message = message;
        Type = type;
        Options = option;
    }
    
    public MessageTemplate(IMessage message)
    {
        Id = Guid.NewGuid();
        Title = message.Title;
        Message = message.Message;
        Type = message.Type;
    }
    
    public MessageTemplate(IMessage message, MessageOption option)
    {
        Id = Guid.NewGuid();
        Title = message.Title;
        Message = message.Message;
        Type = message.Type;
        Options = option;
    }
    
    public MessageTemplate(Guid id, IMessage message)
    {
        Id = id;
        Title = message.Title;
        Message = message.Message;
        Type = message.Type;
    }
    
    public MessageTemplate(Guid id, IMessage message, MessageOption option)
    {
        Id = id;
        Title = message.Title;
        Message = message.Message;
        Type = message.Type;
        Options = option;
    }
    
    public MessageTemplate(IMessage message, Guid id)
    {
        Id = id;
        Title = message.Title;
        Message = message.Message;
        Type = message.Type;
    }
    
    public MessageTemplate(IMessage message, Guid id, MessageOption option)
    {
        Id = id;
        Title = message.Title;
        Message = message.Message;
        Type = message.Type;
        Options = option;
    }
    
    public MessageTemplate Configure(Action<MessageTemplate> configure)
    {
        configure(this);
        return this;
    }
}