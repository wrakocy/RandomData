---
applyTo: "Wrak.RandomData/**"
---

# Publishing to NuGet

Publishing happens via [.github/workflows/publish.yml](../workflows/publish.yml), triggered by pushing a `vX.Y.Z` tag. That workflow builds, tests, packs, and pushes to NuGet.org using Trusted Publishing (OIDC) — there is no API key involved anywhere in this flow, and you should never run `dotnet nuget push` directly.

This repo bumps `<Version>` in `Wrak.RandomData.csproj` for every public-facing change (see git history: 3.1.0 → 3.2.0 → 3.3.0). Follow that pattern.

- Propose a version: minor bump for a new/changed generator, patch for an internal fix with no public API change, major for a breaking change.
- **Always get the user's explicit confirmation of the exact X.Y.Z version before tagging** — never assume or reuse a previously-suggested number.
- **Before tagging, verify the tree is clean** — run in order and stop (fix, or ask the user) if any step fails or changes files:
  ```
  dotnet format Wrak.RandomData.slnx --verify-no-changes
  dotnet build Wrak.RandomData.slnx
  dotnet test Wrak.RandomData.Tests/Wrak.RandomData.Tests.csproj
  ```
  If format check fails, run `dotnet format Wrak.RandomData.slnx` to apply fixes, re-run build/test, and get those changes committed first.
- Commit the version bump, then tag and push to release — only after the user's explicit confirmation:
  ```
  git tag -a vX.Y.Z -m "vX.Y.Z"
  git push origin vX.Y.Z
  ```
- Never push the release tag without that confirmation — a published NuGet version cannot be unpublished or overwritten.

One-time repo setup (a `NUGET_USER` secret scoped to the `release` GitHub Environment, a Trusted Publishing policy on nuget.org for `wrakocy/RandomData` → `publish.yml`, and the `release` environment's required-reviewer rule) is out of scope for a normal publish — only touch it if explicitly asked.
