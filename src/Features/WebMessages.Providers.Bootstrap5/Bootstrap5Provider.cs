using System.Text;
using WebMessages.Foundation;

namespace WebMessages.Providers.Bootstrap5;

public class Bootstrap5Provider : IMessageProvider
{
    public string Render<T>(T message) where T : IMessage
    {
        StringBuilder sb = new StringBuilder();
        var a = "<div id=\"{0}\" class=\"alert alert-{1} alert-dismissible\" role=\" alert\">" +
                (string.IsNullOrEmpty(message.Title) ? "" : "<h3 class=\"alert-heading h4 my-2\">{2}</h3>") +
                "<p class=\"mb-0\">"
                + "{3}" +
                "</p>" +
                (message.Options.ShowCloseButton
                    ? "<button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>"
                    : "")
                + "</div>";
        sb.Append(string.Format(a, message.Id.ToString(), GetAlertStyl(message.Type), message.Title, message.Message));
        return sb.ToString();
    }
    
    public string GetAlertStyl(MessageType type) => type switch
    {
        MessageType.Success => "success",
        MessageType.Info => "info",
        MessageType.Warning => "warning",
        MessageType.Error => "danger",
        _ => "primary"
    };
    
}