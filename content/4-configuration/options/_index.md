---
title: "Options"
weight: 1
---

## <i class="far fa-check-circle"></i> The Options Pattern

In __ASP.NET Core__ we have many potential sources for which we can map configurations from. The official documentation calls attention to all of the following possible configuration sources:

 - Azure Key Vault
 - Command-line arguments
 - Custom providers (installed or created)
 - Directory files
 - Environment variables
 - In-memory .NET objects
 - Settings files

For our application, we only need to rely on two - the settings files and environment variables.

{{% notice warning %}}
As a developer you're ultimately responsible for actively thinking about security throughout the entire development life cycle. Never store sensitive data, such as passwords or secrets in settings files for configuration.
{{% /notice %}}

## The `appsettings.json` File

You may have noticed that there is an `appsettings.json` file in the root of our project. This file contains settings for our application. This file is loaded into our application at start up. During the start up an instance of the `IConfiguration` is injected into the `Startup` class constructor. This has the settings from the JSON file as well as all the other sources that were available. We can use this configuration instance to configure a mapping to a strongly-typed __C#__ settings class. Add a folder named _Configuration_ - then add a new __C#__ file named `BrewerySettings.cs` with the contents below.

```csharp
using System;

namespace AspNet.Essentials.Workshop.Configuration
{
    public class BrewerySettings
    {
        /// <summary>
        /// The base URL to the BreweryDB API endpoint.
        /// </summary>
        public Uri BaseUrl { get; set; }

        /// <summary>
        /// The BreweryDB API key, used to execute API calls.
        /// </summary>
        public string ApiKey { get; set; }
    }
}
```

Then back over in our `Startup.cs` file, find the `ConfigureServices` method and add the following snippet after the addition of MVC.

```csharp
services.Configure<BrewerySettings>(
    Configuration.GetSection(nameof(BrewerySettings)));
```

{{% notice note %}}
You will need to also add a `using AspNet.Essentials.Workshop.Configuration` statement.
{{% /notice %}}

At this point the application is going to take the `appsettings.json` contents and map it to an instance of our `BrewerySettings` class wrapped in an `IOptions` interface. The only problem is that our JSON file doesn't have any custom settings - let's add some. Copy the snippet below , replacing the contents of the `appsettings.json` file.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*",
  "BrewerySettings": {
    "BaseUrl": "https://sandbox-api.brewerydb.com/v2/",
    "ApiKey": "[ NEVER STORE SENSITIVE DATA HERE ]"
  } 
}
```

Notice that while we have potentially sensitive bits of information, we're not actually placing it in this file. That would be a _HUGE_ mistake.  Instead, these are best as "Environment Variables", Azure Key Vault, User Secrets or other secure mechanisms - more on that later. Now we have contents in our __JSON__ that will map to our __C#__ instance. This will enable the controllers and services to take on an `IOptions<BrewerySettings>` parameter in their constructor. We will cover "Dependency Injection" in a later chapter.

#### Additional Resources

Here is the official <a href='https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.2' target='_blank'>Microsoft Docs <i class="fas fa-file-alt"></i></a> on Configuration.
