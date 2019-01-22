---
title: "Options"
weight: 1
---

## The Options Pattern

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

## The `appsettings` File

You may have noticed that there is an `appsettings.json` file in the root of our project. This file contains settings for our application. This file is loaded into our application at start up - it's what is injected into the `Startup` classes constructor as the `IConfiguration` interface. We can use this configuration instance to configure a mapping to a __C#__ settings class. Now add a folder named `Configuration` - then add a new __C#__ file named `NasaSettings` with the contents below.

```cs
using System;

namespace AspNet.Essentials.Workshop.Configuration
{
    public class NasaSettings
    {
        public Uri BaseUrl { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
    }
}
```

Then back over in our `Startup.cs` file, find the `ConfigureServices` method and add the following snippet after the addition of MVC.

```cs
services.Configure<NasaSettings>(
    Configuration.GetSection(nameof(NasaSettings)));
```

{{% notice note %}}
You will need to also add a `using AspNet.Essentials.Workshop.Configuration` statement.
{{% /notice %}}

At this point the application is going to take the `appsettings.json` contents and attempt to map it to an instance of our `NasaSettings` class wrapped in an `IOptions` interface. The only problem is that our JSON file doesn't have any custom settings - let's add some. Copy the snippet below , replacing the contents of the `appsettings.json` file.

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*",
  "NasaSettings": {
    "BaseUrl": "https://www.weather.gov/api/v2",
    "ApiKey": "[ NEVER DO THIS ]",
    "ApiSecret": "[ NEVER ACTUALLY PUT SECRETS HERE ]" 
  } 
}
```

Notice that while we have two potentially sensitive bits of information, we're not actually placing them in this file. That would be a HUGE mistake.  Instead, these are best as "Environment Variables", Azure Key Vault, other secure mechanisms - more on that later. Now we have contents in our __JSON__ that will map to our __C#__ instance. This will enable the controllers and services to take on an `IOptions<NasaSettings>` parameter in their constructor. More details regarding this in the "Dependency Injection" chapter later.

#### Additional Resources

Here is the official <a href='https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.2' target='_blank'>Microsoft Docs <i class="fas fa-file-alt"></i></a> on Configuration.
