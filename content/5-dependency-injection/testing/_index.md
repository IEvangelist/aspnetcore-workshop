---
title: "Testing"
weight: 2
---

## <i class="fas fa-vial"></i> Unit Testing

From within __Visual Studio__, right-click on the solution in the _Solution Explorer_ - then select `Add > New Project`. Under _Installed > Visual C# > .NET Core_ select `xUnit Test Project (.NET Core)` and enter a _Name_ - then click __Ok__.

![New Unit Test Project](/5-dependency-injection/testing/images/new-unittest-proj.png?classes=border,shadow)

#### Add Project Reference

Next, we need to add a reference to our web application within our unit test project. From within the _Solution Explorer_ under the newly created project, right-click on the __Dependencies__ and click `Add Reference...`.

![Add Project Reference](/5-dependency-injection/testing/images/add-proj-ref.png?classess=border,shadow)

From the dialog, check the web application checkbox and click __Ok__.

![Add Project Reference](/5-dependency-injection/testing/images/finalize-proj-ref.png?classess=border,shadow)

#### Manage NuGet Packages

Right-click on the unit test project and click `Manage NuGet Packages...`. Select the __Browse__ tab, search for `"Moq"` and _Install_ it. Now, search for and install the `"Microsoft.AspNetCore.App"` package. At this point the `.csproj` file should look similar to the following:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netcoreapp2.2</TargetFramework>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="15.9.0" />
    <PackageReference Include="Microsoft.AspNetCore.App" />
    <PackageReference Include="Moq" Version="4.10.1" />
    <PackageReference Include="xunit" Version="2.4.0" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.4.0" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\AspNet.Essentials.Workshop\AspNet.Essentials.Workshop.csproj" />
  </ItemGroup>

</Project>
```