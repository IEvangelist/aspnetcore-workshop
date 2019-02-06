---
title: "Precedence"
weight: 2
---

## <i class="fas fa-sort"></i> Precedence

It's important to consider the aforementioned flow of execution for middleware within __ASP.NET Core__. Precedence is a huge factor! The order in which middleware is added is the order in which it is executed. Imagine an HTTP request, the __ASP.NET Core__ runtime will accept the request and start executing all the middleware for the application. Depending on which middleware is executed, it may early exit.