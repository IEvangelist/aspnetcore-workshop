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

#### Additional Resources

Here is the official <a href='https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.2' target='_blank'>Microsoft Docs <i class="fas fa-file-alt"></i></a> on Configuration.
