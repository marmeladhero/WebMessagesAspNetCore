using Microsoft.Extensions.DependencyInjection;
using WebMessages.Foundation;

namespace WebMessages;

public static class RegisterServices
{
    public static IMessageRegistration AddWebMessages(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IWebMessages, MessagesService>();
        return new MessageRegistration(serviceCollection);
    }
}