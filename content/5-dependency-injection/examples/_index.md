---
title: "Examples"
weight: 1
---

## <i class="fas fa-highlighter"></i> Examples

In the root of the project, create the following folders:

 - `Abstractions`
 - `Models`
 - `Services`

In the `Abstractions` folder, create a new C# interface file named `IBreweryClient.cs`. Copy the snippet below into this file.

```csharp
using System.Threading.Tasks;
using AspNet.Essentials.Workshop.Models;

namespace AspNet.Essentials.Workshop.Abstractions
{
    public interface IBreweryClient
    {
        Task<Results> GetBeersAsync();
    }
}
```

This interface exposes an asynchronous function that promises to eventually yield a `Results` object. Let's define that object and several others. In the `Models` folder we will add several model files. For simplicity, download the files from the listing below saving them into the `Models` folder.

{{%attachments title="Models" style="blue"%}}

In the `Services` folder add a `BreweryClient.cs` file, and paste the snippet below into it.

```csharp
using AspNet.Essentials.Workshop.Abstractions;
using AspNet.Essentials.Workshop.Configuration;
using AspNet.Essentials.Workshop.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspNet.Essentials.Workshop.Services
{
    public class BreweryClient : IBreweryClient
    {
        readonly HttpClient _client;
        readonly BrewerySettings _brewerySettings;

        public BreweryClient(HttpClient client, IOptions<BrewerySettings> options)
        {
            _client = client;
            _brewerySettings = options?.Value;
        }

        public async Task<Results> GetBeersAsync()
        {
            var beersJson =
                await _client.GetStringAsync(
                    $"beers?key={_brewerySettings.ApiKey}&order=random&randomCount=10");

            return JsonConvert.DeserializeObject<Results>(beersJson);
        }
    }
}
```

This implementation of the `IBreweryClient` interface defines two constructor parameters. The first is the `HttpClient` and the second is the `IOptions<BrewerySettings>` instance. The brewery settings / options has already been configured in the `Startup.cs` class. We will now add the `HttpClient`. 

{{% notice note %}}
Most C# developers have been using the `HttpClient` wrong for years without realizing it. With __ASP.NET Core__ the `HttpClientFactory` and the ability to map the `HttpClient` to implementations solves this issue. Here is the article if you're curious why <a href='https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/' target='_blank'>you're using HttpClient wrong.</a>
{{% /notice %}}

Open the `Startup.cs` file and in the `ConfigureServices` function, beneath the `services.Configure<BrewerySettings>()` method invocation add the snippet below.

```csharp
services.AddHttpClient<IBreweryClient, BreweryClient>((svc, client) =>
{
    var options = svc.GetService<IOptions<BrewerySettings>>();
    client.BaseAddress = options?.Value?.BaseUrl;
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});
```

This maps the `HttpClient` parameter in the constructor of the `BreweryClient` to the instance we've configured. We provide a lambda function that is given the `IServiceProvider` and `HttpClient` instance. We get the `IOptions<BrewerySettings>` and assign the base address from our settings. We then specify a default request header, adding the `"Accept"` header with a value of `"application/json"`.