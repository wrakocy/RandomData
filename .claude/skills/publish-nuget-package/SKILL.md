---
name: publish-nuget-package
description: Publish a new Wrak.RandomData version to NuGet after a feature or refactor is complete. Use at the end of a change to propose a version bump and cut a release — never push a release tag without the user confirming the exact version number first.
---

# Publishing to NuGet

Publishing happens via [.github/workflows/publish.yml](../../../.github/workflows/publish.yml), triggered by pushing a `vX.Y.Z` tag. That workflow builds, tests, packs, and pushes to NuGet.org using Trusted Publishing (OIDC) — there is no API key involved anywhere in this flow, and this skill never runs `dotnet nuget push` itself.

This repo bumps `<Version>` in `Wrak.RandomData.csproj` for every public-facing change (see git history: 3.1.0 → 3.2.0 → 3.3.0, each adding/changing a generator). Follow that pattern.

1. **When a feature or refactor is complete**, ask the user if they want to publish a new package version. Don't publish unprompted.
2. **Propose a version number** based on semver plus this repo's convention:
   - New/changed generator or other public API addition → bump minor (`3.3.0` → `3.4.0`).
   - Bug fix or internal refactor with no public API change → bump patch (`3.3.0` → `3.3.1`).
   - Breaking change to an existing generator's signature or behavior → bump major.
3. **Wait for the user to explicitly confirm the exact version number.** Never proceed on an assumed or previously-suggested version — always get their confirmation of the final X.Y.Z before tagging.
4. **Update `<Version>`** in [Wrak.RandomData/Wrak.RandomData.csproj](../../../Wrak.RandomData/Wrak.RandomData.csproj) to match, if it isn't already there.
5. **Verify the tree is clean before releasing** — run these in order and stop (and fix, or ask the user) if any of them fail or change files:
   ```
   dotnet format Wrak.RandomData.slnx --verify-no-changes
   dotnet build Wrak.RandomData.slnx
   dotnet test Wrak.RandomData.Tests/Wrak.RandomData.Tests.csproj
   ```
   If `dotnet format --verify-no-changes` fails, run `dotnet format Wrak.RandomData.slnx` to apply fixes, re-run build and test, and get those formatting changes committed before continuing.
   You can also sanity-check the package locally without publishing: `dotnet pack Wrak.RandomData.slnx -c Release -p:Version=X.Y.Z -o artifacts`.
6. **Commit** the version bump (and any formatting fixes) if not already committed.
7. **Tag and push** — this is the step that triggers the publish workflow, so only do it after the user's explicit confirmation from step 3:
   ```
   git tag -a vX.Y.Z -m "vX.Y.Z"
   git push origin vX.Y.Z
   ```
8. If the workflow's `release` GitHub Environment has required reviewers configured, it will pause for a human approval click before the actual NuGet push — point the user to the Actions tab if so.
9. This is irreversible — a published NuGet version can't be unpublished or overwritten. If anything about the version number, test results, or package contents is uncertain, stop and ask rather than guessing.

## One-time repo setup (not part of a normal publish — do only if asked)

- A `NUGET_USER` secret (nuget.org profile name, not email) must exist, scoped to the `release` GitHub Environment (Settings → Environments → `release` → Environment secrets) rather than as a plain repository secret — that way it's only exposed to a run that's already passed the required-reviewer approval.
- A Trusted Publishing policy must exist on nuget.org (Account → Trusted Publishing) for repository owner `wrakocy`, repository `RandomData`, workflow file `publish.yml`.
- Optionally, a `release` GitHub Environment with required reviewers, for a manual approval gate on every publish.
