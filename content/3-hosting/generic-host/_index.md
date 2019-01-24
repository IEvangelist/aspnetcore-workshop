---
title: "Generic Host"
weight: 1
---

## <i class="fas fa-sitemap"></i> Generic Host

The <a href='https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host?view=aspnetcore-2.2' target='_blank'>__ASP.NET Core Generic Host__</a> is used for applications that do not process HTTP requests. This workshop will not cover the usage of a generic host, but it is good to know that one is available.

> The goal of the Generic Host is to decouple the HTTP pipeline from the Web Host API to enable a wider array of host scenarios. Messaging, background tasks, and other non-HTTP workloads based on the Generic Host benefit from cross-cutting capabilities, such as configuration, dependency injection (DI), and logging.