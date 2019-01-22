---
title: "Flow"
weight: 1
---

# Request / Response Pipeline

In __ASP.NET Core__ the concept of middleware is fully fledged/ The middleware pattern is used to intercept and handle the request/response pipeline. Below is a diagram depicting the middleware flow. Imagine that we have a series of middleware added and used in our __ASP.NET Core__ application. Each middleware is given an opportunity to execute as long as the previous middleware do not early exit. In some cases a middleware might fully satisfy a request and early exit - this will prevent the `next` middleware in the sequence from executing.

{{<mermaid>}}
sequenceDiagram
    participant Middleware 1
    participant Middleware 2
    Note over Middleware 1: Some logic
    Middleware 1->>Middleware 2: next();
    Note over Middleware 2: Some logic
    Middleware 2->>Middleware 3: next();
    participant Middleware 4
    Note over Middleware 3: Request satisfied
    Note over Middleware 4: Never executed!
    Middleware 3->>Middleware 2: More logic
    Middleware 2->>Middleware 1: More logic
{{< /mermaid >}}