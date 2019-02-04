+++
title = "Developer Workshop"
weight = 5
+++

# ASP.NET Core Essentials - Developer Workshop

Welcome and thank you for joining me. In this workshop we're going to cover the vast majority of the concepts that are considered first class citizens of __ASP.NET Core__. As a workshop participant you should expect to learn about __ASP.NET Core__ Conventions, Configuration, Hosting, Dependency Injection, Middleware, Routing, Logging, Security and much more.

{{% notice info %}}
We __will not__ spend any time learning _MVC_ or _HTML_ returning endpoints. Instead, we'll focus more on the essential capabilities and building blocks that __ASP.NET Core__ have to offer.
{{% /notice %}}

## Brief History of Active Server Pages

__Active Server Pages__ (ASP) has been around for a long time...__ASP Classic__ was originally introduced in 1996. We've come a long way since then, with dramatic improvements along the way. In 2002 __ASP.NET Framework__ was released alongside version 1.0 of the __.NET Framework__. Fast forward 13 years to 2015 when __ASP.NET 5__, later re-branded __ASP.NET Core__ was born! As a technology there has been 23 years of innovation and I'm excited to share this essentials workshop with you all.

{{% notice note %}}
__ASP Classic__ is a dead and unsupported technology. Do not expect to hear anymore references to it. Likewise, __ASP.NET Framework__ support has a finite lifetime and it is currently believed that soon Microsoft will discontinue support and active development. It is advised to start embracing __ASP.NET Core__ & __.NET Core__ for all future __.NET__ projects.
{{% /notice %}}

## Key Differences

 - Configuration is no longer managed via the `web.config`
 - The `Global.asax` and `App_Start` conventions have been replaced
 - The `wwwroot` no longer contains `CSS` or `JS`
 - Kestrel is the preferred web-server as it is cross-platform
 - New tooling with extensible __.NET CLI__ `dotnet`

## Goals

This __ASP.NET Core Essentials - Developer Workshop__ was designed with the participant in mind. We are going to build an __ASP.NET Core Web API__ application with a theme of <i class="fas fa-beer"></i> beer. We will explore all the essentials necessary to comfortably use __ASP.NET Core__ in the wild.