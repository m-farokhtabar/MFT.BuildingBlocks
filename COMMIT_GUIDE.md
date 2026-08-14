# Commit Message Guide

Standard: **Conventional Commits** — the most widely-adopted industry standard, compatible with Nerdbank.GitVersioning and automated changelog tools.

---

## General Structure

```
<type>(<scope>): <subject>

<body>

<footer>
```

Only `<type>` and `<subject>` are required; `<scope>`, `<body>`, and `<footer>` are optional.

---

## Types — Main Table

| Type | Use case | Example |
|---|---|---|
| `feat` | A new feature | `feat(order): add AddLine method to Order aggregate` |
| `fix` | A bug fix | `fix(entity): resolve transient entity equality bug` |
| `refactor` | Code restructuring without behavior change | `refactor(seedwork): move equality logic to base Entity` |
| `docs` | Documentation only | `docs(readme): add usage example for LocalEntity` |
| `test` | Adding or fixing tests | `test(order): add unit tests for OrderLine equality` |
| `chore` | Maintenance tasks (build, config, dependencies) | `chore(deps): update Nerdbank.GitVersioning to 3.6.0` |
| `style` | Formatting only, no logic change (spacing, semicolons, etc.) | `style(entity): fix indentation` |
| `perf` | Performance improvement | `perf(repository): reduce query allocations` |
| `build` | Changes to the build system or external dependencies | `build: configure GitHub Actions publish workflow` |
| `ci` | Changes to CI/CD configuration files | `ci: add fetch-depth to checkout step` |
| `revert` | Reverting a previous commit | `revert: revert "feat(order): add AddLine method"` |

---

## Scope (optional but highly recommended)

The part of the project affected by the change — for your project, examples include:

```
feat(domain): ...
feat(seedwork): ...
fix(order): ...
fix(entity): ...
chore(infrastructure): ...
docs(application): ...
```

---

## Subject — Exact Rules

1. **Imperative mood** — as if giving a command, not describing the past
   - ✅ `add`, `fix`, `change`
   - ❌ `added`, `fixed`, `changed`, `adding`

2. **Lowercase first letter**
   - ✅ `feat: add order validation`
   - ❌ `feat: Add order validation`

3. **No period at the end**
   - ✅ `fix: resolve null reference`
   - ❌ `fix: resolve null reference.`

4. **Keep it short — under 50 characters** (first line)

---

## Body (optional — explains the "why")

```
fix(entity): resolve transient entity equality bug

Two newly-created entities with default Id (0 or Guid.Empty) were
incorrectly considered equal. Added IsTransient() check to prevent
false-positive equality before persistence.
```

Note: the body should explain **"why"**, not "what" (the "what" is already visible in the diff).

---

## Footer — For Breaking Changes

If a commit introduces a breaking change (critical for Semantic Versioning):

```
feat(order): change OrderLine identity to composite key

BREAKING CHANGE: OrderLineId now requires OrderId as part of its
identity. Existing code calling OrderLine.Create() must be updated
to pass the parent OrderId.
```

A `BREAKING CHANGE:` footer causes tools like semantic-release to automatically bump the major version (`0.x` → or later `1.x` → `2.x`).

---

## Full Real-World Examples (based on your project)

```
feat(seedwork): add LocalEntity with OwnerId scoping

fix(seedwork): prevent cross-aggregate entity equality false positive

refactor(seedwork): make audit methods internal to prevent misuse

docs(seedwork): add CHANGES.md explaining LocalEntity fix

chore(versioning): configure Nerdbank.GitVersioning with alpha channel

ci: add NuGet publish workflow triggered on main branch push

feat(order)!: require OwnerId for all OrderLine creation

BREAKING CHANGE: OrderLine.Create() signature changed to require
parent OrderId as first parameter.
```

Note: the `!` mark after `type(scope)` is a shorter way to signal a breaking change (in addition to, or instead of, the `BREAKING CHANGE:` footer).

---

## Quick Checklist Before Every Commit

```
[ ] Correct type chosen? (feat/fix/refactor/docs/test/chore/...)
[ ] Scope specified (optional but recommended)?
[ ] Subject starts with an imperative verb?
[ ] Subject is under 50 characters?
[ ] If breaking change, is BREAKING CHANGE: or ! included?
[ ] If the change is complex, does the body explain "why"?
```

---

## Why This Standard (Instead of a Custom Format)

1. **Compatible with Semantic Versioning** — `feat` → minor bump, `fix` → patch bump, `BREAKING CHANGE` → major bump
2. **Convertible into automated changelogs** — tools like `Versionize` or `semantic-release` generate changelogs directly from this format
3. **Searchable history** — `git log --grep="^fix"` finds all bug fixes instantly
4. **Globally recognized standard** — any developer joining the project understands it immediately

---

## Official Source

https://www.conventionalcommits.org/en/v1.0.0/
