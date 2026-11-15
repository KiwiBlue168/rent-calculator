# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Commands

Run from the repo root (`RentCalculator.sln`):

```
dotnet build
dotnet test
dotnet test --filter "FullyQualifiedName~RentCalculator.Tests.UnitTest1.Test1"   # single test
dotnet test --filter "FullyQualifiedName~RentCalculator.Tests.UnitTest1"         # single class
```

No linter or formatter is configured beyond the compiler (`Nullable` and `ImplicitUsings` are enabled in both projects).

## Environment notes

- `global.json` pins the SDK to 8.0.428 (`rollForward: latestFeature`). This machine also has old 2.1.x and 5.0 SDKs; the pin keeps them from being picked up.
- If `dotnet` or `gh` isn't on PATH in a session, call them by full path: `C:\Program Files\dotnet\dotnet.exe`, `C:\Program Files\GitHub CLI\gh.exe`.
- Restore prints `NU1803` warnings about an HTTP NuGet feed (`lpnugetserver.azurewebsites.net`). It comes from the machine-wide NuGet config, not this repo; ignore it.

## Structure

- `src/RentCalculator` — class library (`net8.0`), holds the domain logic.
- `tests/RentCalculator.Tests` — xUnit tests; references the library via `ProjectReference`. `Xunit` is a global using, so test files don't need `using Xunit;`.

The repo is a fresh scaffold: `Class1.cs` and `UnitTest1.cs` are template placeholders with no rent-calculation logic yet. Replace them as real code is added.

## Git

- Default branch is `main`; remote `origin` is `https://github.com/KiwiBlue168/rent-calculator.git`.
- The installed Git is old (no `git branch --show-current`); use `git rev-parse --abbrev-ref HEAD` instead.
