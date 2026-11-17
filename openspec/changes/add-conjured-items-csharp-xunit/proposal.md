## Why

The C# xUnit implementation currently treats `Conjured Mana Cake` as an ordinary item, so its quality does not degrade at the required accelerated rate. Adding explicit Conjured behavior brings this implementation in line with the kata requirements while preserving the behavior of all existing item categories.

## What Changes

- Add Conjured quality decay to the C# xUnit implementation, recognizing item names with the `Conjured ` prefix.
- Cover the new decay behavior and its expiration and quality-floor boundaries with focused xUnit tests.
- Preserve existing behavior for ordinary items, Aged Brie, Backstage passes, and Sulfuras.
- Do not modify the `Item` class or implementations for other languages and test frameworks.
- Conjured items lose 2 Quality points per day before expiration and 4 points per day when SellIn is zero or negative, without allowing Quality to fall below zero.

## Capabilities

### New Capabilities
- `conjured-items`: Defines accelerated quality decay for Conjured items in the C# xUnit implementation.

### Modified Capabilities

## Impact

- Production code: `csharp.xUnit/GildedRose/GildedRose.cs`.
- Tests: `csharp.xUnit/GildedRoseTests/GildedRoseTest.cs`.
- No public API, package, or dependency changes.
