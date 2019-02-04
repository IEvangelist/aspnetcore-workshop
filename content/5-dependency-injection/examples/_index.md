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

This interface exposes an asynchronous function that promises to eventually yield a `Results` object. Let's define that object and several others. In the `Models` folder we will add several model files. For simplicity, <i class="fas fa-file-download"></i> download the files from the listing below and <i class="fas fa-save"></i> save them into the `Models` folder.

{{%attachments title="Models" style="grey"%}}

In the `Services` folder add a `BreweryClient.cs` file, and paste the snippet below into it.

```csharp
using AspNet.Essentials.Workshop.Abstractions;
using AspNet.Essentials.Workshop.Configuration;
using AspNet.Essentials.Workshop.Models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AspNet.Essentials.Workshop.Services
{
    public class BreweryClient : IBreweryClient
    {
        readonly HttpClient _client;
        readonly ILogger<BreweryClient> _logger;
        readonly string _apiKey;

        public BreweryClient(
            HttpClient client,
            IOptions<BrewerySettings> options,
            ILogger<BreweryClient> logger)
        {
            _client = client;
            _logger = logger;
            _apiKey = options?.Value?.ApiKey;
        }

        public async Task<Results> GetBeersAsync()
        {
            try
            {
                var results =
                    await _client.GetStringAsync(
                        $"beers?key={_apiKey}&order=random&randomCount=10");

                return JsonConvert.DeserializeObject<Results>(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return null;
        }
    }
}
```

This implementation of the `IBreweryClient` interface defines several constructor parameters. The first is the `HttpClient`, then the `IOptions<BrewerySettings>` and finally the `ILogger<BreweryClient>`. The brewery settings / options has already been configured in the `Startup.cs` class. We will now add the `HttpClient`. 

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

We're going to now rename the existing `ValuesController.cs` to `BeersController.cs`. Copy the code snippet below into the renamed `BeersController.cs` file.

```csharp
using AspNet.Essentials.Workshop.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AspNet.Essentials.Workshop.Controllers
{
    [Route("api/beers"), ApiController]
    public class BeersController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get([FromServices] IBreweryClient client)
            => new JsonResult(await client.GetBeersAsync());
    }
}
```

This controller uses the `[FromServices]` attribute, which instructs the runtime to look in the `IServiceProvider` collection of services for a corresponding implementation. In this case the `BreweryClient` matches and is then injected into our controller `Get` action. We asynchronously await the invocation to the `GetBeersAsync` method and return it as a `JsonResult`.