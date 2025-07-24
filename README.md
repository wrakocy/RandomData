[![NuGet](https://img.shields.io/nuget/v/Wrak.RandomData.svg)](https://www.nuget.org/packages/Wrak.RandomData) [![NuGet](https://img.shields.io/nuget/dt/Wrak.RandomData.svg)](https://www.nuget.org/packages/Wrak.RandomData)
[![Build Status](https://wrakocy.visualstudio.com/RandomData/_apis/build/status/wrakocy.RandomData?branchName=main)](https://wrakocy.visualstudio.com/RandomData/_build/latest?definitionId=3&branchName=main)

# RandomData Middleware Package

A class library for generating simple random test data.

# Getting Started

1. Install NuGet package

```
PM> Install-Package Wrak.RandomData
```

2. Add the following using statement:

```
using Wrak.RandomData;
```

3. Generate some random data:

```

var testString = RandomData.As.String(10);
var testInt = RandomData.As.Int(1, 100);
var testLong = RandomData.As.Long(1, 100);
var testDouble = RandomData.As.Double(1, 100);
var testDecimal = RandomData.As.Decimal(1, 100);
var testBool = RandomData.As.Bool();
var testDateTime = RandomData.As.DateTime(2021, 2024);
var testDateOnly = RandomData.As.DateOnly(2021, 2024);
var testTimeOnly = RandomData.As.TimeOnly(1, 23);
var testTimeSpan = RandomData.As.TimeSpan();
var testDayOfWeek = RandomData.As.Enumeration<DayOfWeek>();

```

4. Create your own extension methods:

```

public static partial class RandomDataExtensions
{
    public static string HappyOrSad(this IRandomData random)
    {
        return RandomData.As.Bool() ? "happy" : "sad";
    }
}

...

public void MyMethod()
{
    var result = RandomData.As.HappyOrSad();
    Console.WriteLine($"Feeling {result} today!");
}

```
