---
title: "Web Host"
weight: 2
---

## <i class="fas fa-globe-americas"></i> Web Host

The __ASP.NET Core__ web host is the default hosting mechanism for all __ASP.NET Core__ web application templates. With that said, this is the web host that is used in this workshop. Under the covers, it relies on the __Kestrel__ web server.

> __Kestrel__ is a cross-platform web server for __ASP.NET Core__. __Kestrel__ is the web server that's included by default in __ASP.NET Core__ project templates.

In this section we're going to discuss the various approaches to host our __ASP.NET Core__ application.
___

### Cross-Platform Web Server

The cross-platform nature of __ASP.NET Core__ is possible via the __Kestrel__ web server. Kestrel can be used directly or as a reverse proxy, with IIS for example. Here is the difference between these two approaches.

#### Kestrel Standalone

{{<mermaid>}}
graph LR;
    A("fa:fa-globe-americas Internet")==HTTP===B("fa:fa-server Kestrel");
    B==HttpContext===C("fa:fa-code Application Code");
    classDef d stroke-dasharray:5,5;
    classDef b stroke:#000,stroke-width:2px;
    classDef blue fill:#33a1ff; 
    classDef orange fill:#f37f1c;
    class A b
    class A d
    class B orange
    class B b
    class C blue
    class C b
{{< /mermaid >}}

#### Kestrel w/ Reverse Proxy

{{<mermaid>}}
graph LR;
    A("fa:fa-globe-americas Internet")==HTTP===B("fa:fa-arrows-alt-h Reverse Proxy (IIS, Nginx, Apache)");
    B==HTTP===C("fa:fa-server Kestrel");
    C==HttpContext===D("fa:fa-code Application Code");
    classDef d stroke-dasharray:5,5;
    classDef b stroke:#000,stroke-width:2px;
    classDef blue fill:#33a1ff;
    classDef orange fill:#f37f1c;
    classDef cyan fill:#1cf3eb;
    class A b
    class A d
    class B cyan
    class B b
    class C orange
    class C b
    class D blue
    class D b
{{< /mermaid >}}

 {{% notice note %}}
There are no performance implications either way. The choice is yours and depends entirely on how comfortable you are with the environment in which you'd prefer to deploy to and work with.
{{% /notice %}}

### Application Lifetime Events

Developers who are coming from the __ASP.NET Framework__ world are accustomed to various application life-cycle hooks. Things like `App_Start` and `App_End` have since been replaced conceptually with another approach. The `IApplicationLifetime` interface provides several key `CancellationToken` properties. They are exposed such that developer's can register an `Action` to be executed on their occurrence. Add the `IApplicationLifetime` and `ILogger<Startup>` interfaces as arguments to the `Startup.Configure` method signature.

```csharp
public void Configure(
    IApplicationBuilder app,
    IHostingEnvironment env,
    IApplicationLifetime lifetime,
    ILogger<Startup> logger)
{
    // omitted for brevity...
}
```

Next, add the following methods to the start up class.

```csharp
static void OnStarted(ILogger logger)
    => logger.LogInformation("The application has started... post-startup logic here.");

static void OnStopping(ILogger logger)
    => logger.LogInformation("The application has stopping... stopping logic here.");

static void OnStopped(ILogger logger)
    => logger.LogInformation("The application has stopped... post-stopped logic here.");
```

Now, we'll register delegates that act as callbacks. They'll be invoked at different points in the application lifetime.

```csharp
lifetime.ApplicationStarted.Register(o => OnStarted(o as ILogger), logger);
lifetime.ApplicationStopping.Register(o => OnStopping(o as ILogger), logger);
lifetime.ApplicationStopped.Register(o => OnStopped(o as ILogger), logger);
```