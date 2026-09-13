# Wrak.RandomData

A tiny, zero-dependency .NET class library that generates random test data via extension methods on `IRandomData`, accessed through the `RandomData.As` singleton (e.g. `RandomData.As.Int(1, 100)`). Multi-targets net6.0–net9.0. Published to NuGet as `Wrak.RandomData`.

## Build & test

```
dotnet build Wrak.RandomData.sln
dotnet test Wrak.RandomData.Tests/Wrak.RandomData.Tests.csproj
```

CI is **Azure Pipelines** (`azure-pipelines.yml`), not GitHub Actions — don't assume an Actions-based CI exists.

## Architecture

- [Wrak.RandomData/RandomData.cs](Wrak.RandomData/RandomData.cs) — the `IRandomData` marker interface and the `RandomData.As` singleton entry point. Keep it empty otherwise.
- [Wrak.RandomData/RandomDataExtensions.cs](Wrak.RandomData/RandomDataExtensions.cs) — every generator is a `public static` extension method on `IRandomData`, defined in a `static partial class RandomDataExtensions`. This partial-class pattern is the library's whole extensibility story (README §4 shows consumers adding their own generators the same way) — don't move generators onto another type or make the class non-partial.
- One shared `private static readonly Random _rnd` backs all generators — never `new Random()` inside a method.

## Guardrails

- **Always** validate range/bound arguments (`minValue <= maxValue`, in-bounds years/hours/etc.) and throw `ArgumentException`/`ArgumentOutOfRangeException` with `nameof(...)` in the message, matching the existing methods' style.
- **Always** bump `<Version>` in [Wrak.RandomData.csproj](Wrak.RandomData/Wrak.RandomData.csproj) for any change to the public API — every prior feature commit does this; it drives the NuGet package version.
- **Never** add a package dependency to `Wrak.RandomData` — it must stay zero-dependency. Test-only dependencies belong in `Wrak.RandomData.Tests` only.
- **Never** drop or narrow a `<TargetFrameworks>` entry without being asked.

## Tests

xUnit, one class per generated type named `RandomDataExtensions_<Type>` in a matching `RandomDataExtensions_<Type>.cs` file. Range-bound generators get `[Theory]`/`[InlineData]` + `Assert.InRange`. Randomness/distribution properties (e.g. "the value isn't always the default") get a `[Fact]` that loops ~100 iterations and calls `Assert.Fail` only if every iteration missed — never assert on a single random sample.

## Adding a new generator method

Use the `add-random-generator` skill — it walks through the full pattern (method + validation + test file + README update + version bump) end to end.

## Publishing to NuGet

Publishing runs through the `Publish to NuGet` GitHub Actions workflow ([.github/workflows/publish.yml](.github/workflows/publish.yml)) using NuGet Trusted Publishing (OIDC) — there's no API key to manage, and the agent never runs `dotnet nuget push` directly. Pushing the release tag is what triggers the workflow.

After finishing a feature or refactor, ask the user whether to publish a new package version — don't publish unprompted. **Never push a `vX.Y.Z` release tag without the user explicitly confirming the exact version number first**; that push triggers an irreversible publish (a NuGet version can never be overwritten or deleted). Use the `publish-nuget-package` skill for the version-bump conversation and release steps.
