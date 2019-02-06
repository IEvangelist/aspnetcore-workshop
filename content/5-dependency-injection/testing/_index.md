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

## Writing Unit Tests

Unit testing should 

### Not Worthwhile Tests

```csharp
using AspNet.Essentials.Workshop.Configuration;
using AspNet.Essentials.Workshop.Services;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AspNet.Essentials.WorkshopTests
{
    public class BreweryClientTests
    {
        [Fact]
        public async Task GetBeersAsyncReturnsNullOnError()
        {
            // Arrange
            var handler = new Mock<HttpMessageHandler>();
            var httpClient = new HttpClient(handler.Object);

            // Act
            var sut =
                new BreweryClient(
                    httpClient,
                    Options.Create(new BrewerySettings()),
                    NullLogger<BreweryClient>.Instance);

            // Assert
            var results = await sut.GetBeersAsync();
            Assert.Null(results);
        }
    }
}
```

### Worthwhile Tests

```csharp
using AspNet.Essentials.Workshop.Abstractions;
using AspNet.Essentials.Workshop.Enums;
using AspNet.Essentials.Workshop.Models;
using AspNet.Essentials.Workshop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AspNet.Essentials.WorkshopTests
{
    public class BloodAlcoholCalculatorTests
    {
        readonly IBloodAlcoholCalculator _sut;

        public BloodAlcoholCalculatorTests()
            => _sut = new BloodAlcoholCalculator();

        [Fact]
        public void CalculateBloodAlcoholCorrectlyCalculates()
        {
            var beers = new Beer[]
            {
                new Beer { Abv = 7.2 },
                new Beer { Abv = 9.6 },
                new Beer { Abv = 12.7 }
            };

            var expected = 0.0996;
            var actual = _sut.Calculate(225, 3, Sex.Male, beers);

            Assert.Equal(Math.Round(expected, 4), actual);
        }

        [
            Theory,
            InlineData(0.0996, 225, 3, Sex.Male),
            InlineData(0.1109, 175, 5, Sex.Male),
            InlineData(0.1549, 175, 5, Sex.Female),
            InlineData(0.2382, 150, 2, Sex.Female)
        ]
        public void CalculateBloodAlcoholInlineDataCalculateTests(
            float expected,
            int weightInPounds,
            float hoursOfDrinking,
            Sex sex)
        {
            var beers = new Beer[]
            {
                new Beer { Abv = 7.2 },
                new Beer { Abv = 9.6 },
                new Beer { Abv = 12.7 }
            };

            var actual = _sut.Calculate(weightInPounds, hoursOfDrinking, sex, beers);

            Assert.Equal(Math.Round(expected, 4), actual);
        }

        public static IEnumerable<object[]> CalculateInputs =
            new List<object[]>
            {
                new object[] { 0.0996, 225, 3, Sex.Male, new[] { 7.2, 9.6, 12.7 } },
                new object[] { 0.2883, 190, 3.5, Sex.Male, new[] { 7.2, 9.6, 12.7, 5.5, 3.8, 10.9, 9 } },
                new object[] { 0.7970, 135, 1.75, Sex.Female, new[] { 10.2, 9.6, 12.7, 15.5, 13.8, 10.7, 9 } },
                new object[] { 0.1053, 165, 4, Sex.Female, new[] { 5.0, 5.1, 4.9, 5.0 } }
            };

        [
            Theory,
            MemberData(nameof(CalculateInputs))
        ]
        public void CalculateBloodAlcoholMemberDataCalculateTests(
            double expected,
            int weightInPounds,
            double hoursOfDrinking,
            Sex sex,
            double[] abvs)
        {
            var beers = abvs.Select(abv => new Beer { Abv = abv }).ToArray();

            var actual = _sut.Calculate(weightInPounds, hoursOfDrinking, sex, beers);

            Assert.Equal(Math.Round(expected, 4), actual);
        }
    }
}
```