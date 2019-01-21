+++
title = "Developer Workshop"
weight = 5
+++

# ASP.NET Core Essentials - Developer Workshop

Welcome and thank you for joining me. In this workshop we're going to cover the vast majority of the concepts that are considered first class citizens of ASP.NET Core. As a workshop participant you should expect to learn about ASP.NET Core Program and Startup Conventions, Configuration, Dependency Injection, Middleware, Routing, Logging, Security and much more.

{{% notice info %}}
We __will not__ spend any time learning MVC or HTML returning endpoints. Instead, we'll focus more on the essential capabilities and building blocks that ASP.NET Core have to offer.
{{% /notice %}}

## Brief History of Active Server Pages

Active Server Pages (ASP) has been around for a long time...ASP Classic was originally introduced in 1996. We've come a long way since then, with dramatic improvements along the way. In 2002 ASP.NET Framework was released alongside version 1.0 of the .NET Framework. Fast forward 13 years to 2015 and ASP.NET 5, later re-branded ASP.NET Core was born! As a technology there has been 23 years of innovation and I'm excited to share this essentials workshop with you all.

{{% notice note %}}
ASP Classic is a dead and unsupported technology. Do not expect to hear anymore references to it. Likewise, ASP.NET Framework support has a finite lifetime and it is currently believed that soon Microsoft will discontinue support and active development. It is advised to start embracing ASP.NET Core & .NET Core for all future .NET projects.
{{% /notice %}}

## Key Differences

 - Configuration is no longer managed via the `web.config`
 - The `Global.asax` and `App_Start` conventions have been removed
 - The `wwwroot` no longer contains `CSS` or `JS`
 - Kestrel is the preferred web-server as it is cross-platform
 - New tooling with extensible .NET CLI `dotnet`