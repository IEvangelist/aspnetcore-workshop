---
title: "Startup"
---

## Navigating the `Startup.cs`

Again, the templates have some less than desirable bits in them - so let's clean this up and continue on building out our application. Please replace the file contents of the `Startup.cs` with the snippet below.

```cs
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNet.Essentials.Workshop
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
```

The `Startup.cs` class has a simple `.ctor` with a single parameter. This is the `IConfiguration` instance and is provide to our start up from the `IWebHostBuilder` implementation. We assign our `readonly` property from this argument. Next, you'll notice that we have two methods in this class.

### Configure Services

The `ConfigureServices` method has a single parameter of `IServiceCollection`. This is the applications service collection and is used for dependency injection later on, but at this point we need it to add services to and register various bits of middleware.

> Use this method to add services to the container.

```cs
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
}
```

{{% notice tip %}}
If you decide to create custom middleware, remember that there is a very commonly used naming convention. Typically, as a convenience middleware authors will add extension methods on the `IServiceCollection` that allow for the addition of their custom middleware. It is common for these methods to be prefixed with `Add` followed by the name of the service middleware being added. For example, `.AddAuthentication` to add all the authentication services required for authentication to function.
{{% /notice %}}

### Configure

The `Configure` method has two parameters by default, an implementation of the `IApplicationBuilder` and the `IHostingEnvironment`.

> Use this method to configure the HTTP request pipeline.

```cs
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    else
    {
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseMvc();
}
```

{{% notice tip %}}
Since we've already wired up services for dependency injection we could add more parameters to the `Configure` method and they will be correctly resolved. This is not true for the `ConfigureServices` method.
{{% /notice %}}