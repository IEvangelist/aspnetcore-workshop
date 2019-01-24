---
title: "Web Host"
weight: 2
---

## <i class="fas fa-globe-americas"></i> Web Host

... details go here ...

### Cross Platform Web Server

The cross platform nature of __ASP.NET Core__ is possible via the __Kestrel__ web server. Kestrel can be used directly or as a reverse proxy approach, with IIS for example. Here is the difference between the two approaches.

#### Kestrel Standalone

{{<mermaid>}}
graph LR;
    A("fa:fa-globe-americas Internet")--HTTP---B("fa:fa-server Kestrel");
    B--HttpContext---C("fa:fa-code Application Code");
    classDef blue fill:#1c90f3;
    classDef orange fill:#f37f1c;
    class B orange
    class C blue
{{< /mermaid >}}

#### Kestrel w/ Reverse Proxy

{{<mermaid>}}
graph LR;
    A("fa:fa-globe-americas Internet")--HTTP---B("fa:fa-arrows-alt-h Reverse Proxy (IIS)");
    B--HTTP---C("fa:fa-server Kestrel");
    C--HttpContext---D("fa:fa-code Application Code");
    classDef blue fill:#1c90f3;
    classDef orange fill:#f37f1c;
    classDef cyan fill:#1cf3eb;
    class B cyan
    class C orange
    class D blue
{{< /mermaid >}}

### Application Lifetime Events

The `IApplicationLifetime` interface. ... more details and examples, followed by lab.

