---
title: "Precedence"
weight: 2
---

## <i class="fas fa-sort"></i> Precedence

It's important to consider the aforementioned flow of execution for middleware within __ASP.NET Core__. Precedence is a huge factor! The order in which middleware is added is the order in which it is executed. Imagine an HTTP request, the __ASP.NET Core__ runtime will accept the request and start executing all the middleware for the application. Depending on which middleware is executed, it may early exit.

{{% notice warning %}}
One of the most commonly made mistakes is the order in which middleware is added. You need to have a clear understanding that the order does in fact matter.
{{% /notice %}}

### Built-in Middleware

There is a <a href='https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.2#built-in-middleware' target='_blank'>huge listing of built-in middleware</a> that exists for __ASP.NET Core__. If you cannot find something that meets your needs it is easy to write custom middleware that follows these common patterns. Custom middleware is out of scope for this workshop, but details <a href='https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-2.2#write-middleware' target='_blank'>are here</a>.