namespace WebMessages.Foundation;

public interface IMessage
{
    Guid Id { get; }
    string? Title { get; }
    string Message { get; }
    MessageType Type { get; }
    MessageOption Options { get; }
}