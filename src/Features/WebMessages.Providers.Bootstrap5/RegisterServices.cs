using WebMessages.Foundation;

namespace WebMessages.Providers.Bootstrap5;

public static class RegisterServices
{
    public static IMessageRegistration AddBootstrap5Provider(this IMessageRegistration registration)
    {
        registration.AddProvider<Bootstrap5Provider>();
        return registration;
    }
}