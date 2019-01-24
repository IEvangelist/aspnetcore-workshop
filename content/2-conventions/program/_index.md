---
title: "Program"
---

## <i class="fas fa-terminal"></i> Exploring the `Program.cs`

All __ASP.NET Core__ applications are also console applications, meaning they will have a `Program.cs` and a `Main` entry point. The __Visual Studio__ templates are great as a starting point, but they do leave you with some clean up work. Copy and paste the snippet below and replace this with your `Program.cs` file contents - be sure to __<i class="fas fa-save"></i> Save__!

```cs
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AspNet.Essentials.Workshop
{
    public class Program
    {
        public static void Main(string[] args) 
            => CreateWebHostBuilder(args).Build().Run();

        static IWebHostBuilder CreateWebHostBuilder(string[] args)
            => WebHost.CreateDefaultBuilder(args)
                      .UseStartup<Startup>();
    }
}
```

When this application is launched, the `args` are passed into the invocation of the `WebHost.CreateDefaultBuilder` function. This will use those arguments if any were given. It then specifics that we're targeting our `Startup` class. The creation of the default web host builder and the specification of the start up class provide an implementation of the `IWebHostBuilder`, we can then build and run it.

{{% notice tip %}}
__<i class="fas fa-save"></i> Save__ early and often.
{{% /notice %}}