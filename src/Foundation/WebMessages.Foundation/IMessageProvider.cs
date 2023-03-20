namespace WebMessages.Foundation;

public interface IMessageProvider
{
    string Render<T>(T message) where T : IMessage;
}