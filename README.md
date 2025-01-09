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

3. Generate test data:

```

var testString = RandomData.String(10);
var testInt = RandomData.Int(1, 100);
var testLong = RandomData.Long(1, 100);
var testDouble = RandomData.Double(1, 100);
var testDecimal = RandomData.Decimal(1, 100);
var testBool = RandomData.Bool();
var testDate = RandomData.Date(2021, 2024);
var testDayOfWeek = RandomData.Enumeration<DayOfWeek>();

```
