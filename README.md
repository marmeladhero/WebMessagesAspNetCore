# WebMessagesAspNetCore
Web messages for asp net core

### Install
```bash
dotnet add package WebMessages
```
```bash
dotnet WebMessages.Providers.Bootstrap5
```
```bash
dotnet WebMessages.Storages.DistributedCacheStorage
```

### Usage
```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddHttpContextAccessor().AddWebMessages().AddBootstrap5Provider()
    .AddDistributedCacheStorage(x => x.Key = Guid.NewGuid().ToString());
}
```
Example
```csharp
public class HomeController : Controller
{
    private readonly IWebMessageService _webMessageService;

    public HomeController(IWebMessageService webMessageService)
    {
        _webMessageService = webMessageService;
    }

    public async Task<IActionResult> Index()
    {
        await _webMessages.AddMessageAsync(new("Success", "You have registered", MessageType.Success));
        return View();
    }
}
```
```html
@using WebMessages.Foundation
@inject IWebMessages WebMessages
@{
    var messages = await WebMessages.MessagesAsync();

    foreach (var message in messages)
    {
        @Html.Raw(message)
    }
}
```

### Options
```csharp
public class WebMessagesOptions
{
    public string? Path { get; set; }
    public bool DeleteAfterRead { get; set; } = true;
    public bool ShowCloseButton { get; set; } = true;
    public DateTime? ExpirationDate { get; set; }
}
```

