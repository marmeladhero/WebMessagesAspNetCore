namespace WebMessages.Foundation;

public class MessageOption
{
    /// <summary>
    /// Where to show the message.
    /// </summary>
    public string? Path { get; set; }
    
    public bool DeleteAfterRead { get; set; } = true;
    public bool ShowCloseButton { get; set; } = true;
    public DateTime? ExpirationDate { get; set; }
}