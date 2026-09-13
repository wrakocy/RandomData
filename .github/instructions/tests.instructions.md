---
applyTo: "Wrak.RandomData.Tests/**"
---

# Writing tests for RandomData

- One test class per generated type: file `RandomDataExtensions_<Type>.cs`, class `RandomDataExtensions_<Type>`, namespace `Wrak.RandomData.Tests`.
- Range-bound generators: `[Theory]` + `[InlineData(...)]` over at least a normal case and an edge case, asserted with `Assert.InRange`.
- Randomness/distribution properties (non-default value, either branch of a bool, etc.): a `[Fact]` that loops ~100 iterations and only calls `Assert.Fail` if no iteration satisfied the property — never assert on a single random sample (see `RandomDataExtensions_DateTimeOffset.cs` for the pattern).
- Bad-input cases: assert the specific exception type the method throws.
- Test project may depend on xunit/coverlet only — don't add new test frameworks.
