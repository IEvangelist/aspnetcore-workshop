---
title: "Examples"
weight: 1
---

## <i class="fas fa-highlighter"></i> Examples

In the root of the project, add the following folders:

 - Abstractions
 - Enums
 - Models
 - Services

At this point we'll add the models and enums to the folders. Then later we'll walk through the process of adding abstractions and corresponding implementations. In the _Enums_ folder add a new `enum` file named `Sex.cs`.

```csharp
namespace AspNet.Essentials.Workshop.Enums
{
    public enum Sex
    {
        Male,
        Female
    }
}
```
In the _Models_ folder we will add several model files. For simplicity, <i class="fas fa-file-download"></i> download the files from the listing below and <i class="fas fa-save"></i> save them into the _Models_ folder.

{{%attachments title="Models" style="grey"%}}