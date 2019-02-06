---
title: "BAC Calculator"
weight: 2
---

## Blood Alcohol Content Calculator

Let's add another abstraction and corresponding implementation. Start by adding another interface, this time we'll name it `IBloodAlcoholCalculator` in the _Abstractions_ folder.

```csharp
using AspNet.Essentials.Workshop.Enums;
using AspNet.Essentials.Workshop.Models;

namespace AspNet.Essentials.Workshop.Abstractions
{
    public interface IBloodAlcoholCalculator
    {
        double Calculate(
            int weightInPounds,
            double hoursOfDrinking,
            Sex sex,
            params Beer[] beers);
    }
}
```
This interface defines a `Calculate` function which will be used to calculate someones blood alcohol content based on the given parameters. In the _Services_ folder copy the following implementation into the file named _BloodAlcoholCalculator.cs_.

```csharp
using AspNet.Essentials.Workshop.Abstractions;
using AspNet.Essentials.Workshop.Enums;
using AspNet.Essentials.Workshop.Models;
using System;
using System.Linq;

namespace AspNet.Essentials.Workshop.Services
{
    public class BloodAlcoholCalculator : IBloodAlcoholCalculator
    {
        const double PoundsToGramsMultiple = 453.592;
        const double OuncesToGramsMultiple = 340.194;
        const double MaleConstant = 0.68;
        const double FemaleConstant = 0.55;
        const double AlcoholOverTimeDeteriorationConstant = .015;

        const int BacPrecision = 4;

        public double Calculate(
            int weightInPounds,
            double hoursOfDrinking,
            Sex sex,
            params Beer[] beers)
        {
            if (beers is null || beers.Length == 0)
            {
                return 0;
            }

            // Calculation borrowed from:
            // https://www.wikihow.com/Calculate-Blood-Alcohol-Content-(Widmark-Formula)

            var totalAlcoholInGrams = beers.Sum(beer => OuncesToGramsMultiple * (beer.Abv / 100));
            var bodyWeightInGrams = weightInPounds * PoundsToGramsMultiple;
            var weightWithSexConstant = bodyWeightInGrams * (sex == Sex.Male ? MaleConstant : FemaleConstant);
            var rawNumber = totalAlcoholInGrams / weightWithSexConstant;
            var bacPercentage = rawNumber * 100;
            var result = bacPercentage - (hoursOfDrinking * AlcoholOverTimeDeteriorationConstant);

            return Math.Round(result, BacPrecision);
        }
    }
}
```

Next, we'll add a new controller named `BloodAlcoholContentController.cs` with the following contents.

```csharp
using AspNet.Essentials.Workshop.Abstractions;
using AspNet.Essentials.Workshop.Enums;
using AspNet.Essentials.Workshop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNet.Essentials.Workshop.Controllers
{
    [Route("api/bac"), ApiController]
    public class BloodAlcoholContentController : ControllerBase
    {
        [HttpPost("post-body")]
        public ActionResult CalculateFromBodyAsModel(
            [FromBody] BacCalculationRequest request,
            [FromServices] IBloodAlcoholCalculator calculator)
            => new JsonResult(new
               {
                   BloodAlcoholContent =
                       calculator.Calculate(
                           request.WeightInPounds,
                           request.HoursOfDrinking,
                           request.Sex,
                           request.Beers)
               });

        [HttpPost("post-route/{weight:int},{hours:float},{sex}")]
        public ActionResult CalculateFromRoute(
            [FromRoute] int weight,
            [FromRoute] float hours,
            [FromRoute] Sex sex,
            [FromQuery] double[] abvs,
            [FromServices] IBloodAlcoholCalculator calculator)
            => new JsonResult(new
               {
                   BloodAlcoholContent =
                          calculator.Calculate(
                              weight,
                              hours,
                              sex,
                              abvs)
               });
    }
}
```