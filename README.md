![Banner](https://raw.githubusercontent.com/sharpyr/Analys/refs/heads/master/media/analys-banner.svg)

Cross-table analytics

[![Version](https://img.shields.io/nuget/vpre/Analys.svg)](https://www.nuget.org/packages/Analys)
[![Downloads](https://img.shields.io/nuget/dt/Analys.svg)](https://www.nuget.org/packages/Analys)
[![Dependent Libraries](https://img.shields.io/librariesio/dependents/nuget/Analys.svg?label=dependent%20libraries)](https://libraries.io/nuget/Analys)
[![Language](https://img.shields.io/badge/language-C%23-blueviolet.svg)](https://dotnet.microsoft.com/learn/csharp)
[![Compatibility](https://img.shields.io/badge/compatibility-.NET%20Standard%202.0-blue.svg)]()
[![License](https://img.shields.io/github/license/sharpyr/Analys.svg)](https://github.com/sharpyr/Analys/LICENSE)

## Install

Analys targets .NET Standard 2.0, fits both .NET and .NET Framework.

Install [Analys package](https://www.nuget.org/packages/Analys) and sub packages.

NuGet Package Manager:

```powershell
Install-Package Analys
```

.NET CLI:

```shell
dotnet add package Analys
```

All versions can be found [on nuget](https://www.nuget.org/packages/Analys#versions-body-tab).

## Usage

### Create a Crostab

```csharp
using Analys.Crostab
using Spare
using static Palett.Presets;

var table = Crostab<int>.Build(
    new[] {"high", "mid", "low"}, // side
    new[] {"tier 1", "tier 2", "tier 3"}, // head
    new [,] {
        { 960, 660, 240 },
        { 840, 570, 180 },
        { 720, 480, 120 },
    });
table.Deco(tab: 2, presets: (Planet, Fresh)).Logger();
```

>
# Examples
---------------------
Analys has a test suite in the [test project](https://github.com/sharpyr/Analys/tree/master/Analys.Test/Src).

## Feedback

Analys is licensed under the [MIT](https://github.com/sharpyr/Analys/LICENSE) license.

Bug report and contribution are welcome at [the GitHub repository](https://github.com/sharpyr/Analys).


