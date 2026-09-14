---
name: add-random-generator
description: Add a new random-data generator method to Wrak.RandomData (e.g. a new range-bound type, or a custom enum-like generator). Use when asked to add, implement, or extend a random data generator/extension method in this repo.
---

# Adding a random-data generator

Follow every step — the library's public surface, its tests, and the NuGet version all have to move together.

1. **Implement the method** in [Wrak.RandomData/RandomDataExtensions.cs](../../../Wrak.RandomData/RandomDataExtensions.cs):
   - `public static <T> <Name>(this IRandomData _, ...)` on the existing `static partial class RandomDataExtensions`.
   - Use the shared `_rnd` field — don't create a new `Random` instance.
   - If the method takes min/max-style bounds, validate `min <= max` and any hard bounds (e.g. against `DateTime.MinValue`/`MaxValue`), throwing `ArgumentException`/`ArgumentOutOfRangeException` with `nameof(...)` in the message — match the style of the existing `Int`/`DateTime`/`TimeOnly` methods.
   - Give bounded parameters sensible defaults so `RandomData.As.Foo()` works with no arguments, matching every existing generator.

2. **Add a test file**: `Wrak.RandomData.Tests/RandomDataExtensions_<Type>.cs`, class `RandomDataExtensions_<Type>`, namespace `Wrak.RandomData.Tests`.
   - Range-bound generator → `[Theory]` + `[InlineData(...)]` covering at least a normal range and an edge case, asserting with `Assert.InRange`.
   - Any property that depends on randomness (non-default value, both branches of a bool, etc.) → a `[Fact]` that loops (~100 iterations) and calls `Assert.Fail` only if no iteration satisfied the property. Never assert on a single sample.
   - If the method should throw on bad input, add a case asserting the specific exception type.

3. **Update [README.md](../../../README.md)** section 3 (the usage snippet) to include the new call, matching the existing `var testX = RandomData.As.X(...)` style.

4. **Bump `<Version>`** in [Wrak.RandomData/Wrak.RandomData.csproj](../../../Wrak.RandomData/Wrak.RandomData.csproj) — the repo bumps the minor version for each new/changed generator (3.1.0 → 3.2.0 → 3.3.0).

5. **Build and run tests** before finishing:
   ```
   dotnet build Wrak.RandomData.slnx
   dotnet test Wrak.RandomData.Tests/Wrak.RandomData.Tests.csproj
   ```
