---
applyTo: "Wrak.RandomData/**"
---

# Editing the RandomData library

- New generator = extension method `public static <T> <Name>(this IRandomData _, ...)` on the existing `static partial class RandomDataExtensions` in `RandomDataExtensions.cs`. Reuse the shared `private static readonly Random _rnd` — never `new Random()` inside a method.
- Bounded parameters get sensible defaults so the no-argument call works (`RandomData.As.Foo()`), matching every existing generator.
- Validate bounds the way `Int`, `DateTime`, and `TimeOnly` already do: check `minValue <= maxValue` and any hard type limits, and throw `ArgumentException`/`ArgumentOutOfRangeException` whose message includes `nameof(...)`.
- `RandomData.cs` holds only the `IRandomData` marker interface and the `RandomData.As` singleton — keep it empty otherwise.
- After adding or changing a generator, bump `<Version>` in `Wrak.RandomData.csproj` and update the usage snippet in `README.md` §3.
- Keep the project dependency-free; don't add `<PackageReference>` entries here.
