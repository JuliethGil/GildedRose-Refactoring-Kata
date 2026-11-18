## Why

The current C# xUnit implementation concentrates all item update rules inside `GildedRose.UpdateQuality()`. This results in deeply nested conditionals, repeated item-name comparisons, and mixed responsibilities for quality and sell-in updates.

Refactoring this logic will improve readability, maintainability, and extensibility while preserving the existing behavior of all item categories.

## What Changes

- Extract cohesive private methods from `GildedRose.UpdateQuality()` to separate item update responsibilities.
- Separate the handling of quality deterioration, quality improvement, expiration, and sell-in updates where appropriate.
- Reduce nested conditionals and repeated item-name comparisons.
- Preserve all existing business rules, including the previously implemented Conjured behavior.
- Keep `Item.cs` as a data model without introducing additional domain behavior in this change.
- Do not create new projects or modify implementations for other languages and test frameworks.
- Use the existing unit tests and approval tests to verify that the refactoring does not change observable behavior.

## Capabilities

### New Capabilities

### Modified Capabilities

- `gilded-rose-update`: Refactor the internal organization of item update logic while preserving existing business rules.

## Impact

- Production code: `csharp.xUnit/GildedRose/GildedRose.cs`.
- Tests: `csharp.xUnit/GildedRoseTests`.
- No public API, package, or dependency changes.