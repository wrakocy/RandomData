# Wrak.RandomData — Copilot instructions

Tiny, zero-dependency .NET class library that generates random test data via extension methods on `IRandomData`, accessed through the `RandomData.As` singleton (e.g. `RandomData.As.Int(1, 100)`). Multi-targets net6.0–net9.0. Published to NuGet as `Wrak.RandomData`.

## Build & test

```
dotnet build Wrak.RandomData.slnx
dotnet test Wrak.RandomData.Tests/Wrak.RandomData.Tests.csproj
```

CI is Azure Pipelines (`azure-pipelines.yml`) — there is no GitHub Actions workflow.

## Core pattern

Every generator is a `public static` extension method on `IRandomData`, in the `static partial class RandomDataExtensions` (`Wrak.RandomData/RandomDataExtensions.cs`). This is the library's extensibility story — consumers add their own generators the same way (README §4). Don't add generators anywhere else, and don't add members to `IRandomData`/`RandomData` themselves.

## Guardrails

- Always validate range arguments (`min <= max`, hard bounds) and throw `ArgumentException`/`ArgumentOutOfRangeException` with `nameof(...)`, matching existing methods.
- Always bump `<Version>` in `Wrak.RandomData/Wrak.RandomData.csproj` when the public API changes.
- Never add a dependency to the `Wrak.RandomData` project — keep it zero-dependency.
- Never remove or narrow a `<TargetFrameworks>` entry without being asked.

More detail applies automatically when you're editing files under `Wrak.RandomData/` or `Wrak.RandomData.Tests/` — see `.github/instructions/`.

## Publishing

Publishing runs through the `Publish to NuGet` GitHub Actions workflow (`.github/workflows/publish.yml`) via NuGet Trusted Publishing (OIDC) — there's no API key, and you should never run `dotnet nuget push` directly. Pushing a `vX.Y.Z` tag triggers the workflow. After finishing a feature or refactor, ask the user whether to publish — never publish unprompted, and never push a release tag without the user explicitly confirming the exact version number first (that push starts an irreversible publish). See `.github/instructions/publishing.instructions.md` for the version-bump convention and release steps.
