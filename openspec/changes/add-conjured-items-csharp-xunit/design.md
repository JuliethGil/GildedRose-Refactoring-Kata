## Context

The C# xUnit implementation updates items in `GildedRose.UpdateQuality`. It handles ordinary-item deterioration in two stages: once before decrementing `SellIn`, and a second time if the resulting `SellIn` is below zero. Special cases are identified by their existing exact item names. `Item` must remain unchanged, so the existing `Name` value is the available discriminator.

## Goals / Non-Goals

**Goals:**
- Recognize Conjured items by the literal `Conjured ` prefix.
- Apply twice the normal-item deterioration rate, including the additional post-expiration deterioration.
- Preserve the quality floor, one-day `SellIn` decrement, and all existing item rules.
- Restrict production and test changes to `csharp.xUnit`.

**Non-Goals:**
- Modify `Item`, its properties, the public API, package dependencies, or other language implementations.
- Refactor the broader `UpdateQuality` algorithm or change its expiration boundary.
- Extend Conjured behavior to special item categories.

## Decisions

### Apply a decay rate within the existing ordinary-item path

Conjured items will use a decay amount of two instead of one at each existing ordinary-item deterioration point. The amount will be applied only when quality is above zero and will be bounded so quality cannot become negative. The existing ordering of quality changes and the `SellIn` decrement will remain unchanged; consequently, an item whose `SellIn` is zero before the update receives both deterioration stages during that update.

An alternative is to rewrite the full update method or extract a new item hierarchy. Both would expand the change and risk altering special-item behavior or violate the constraint on `Item`.

### Identify items using the agreed name prefix

Use the literal `Conjured ` prefix in `Name`, matching the existing `Conjured Mana Cake` example and the agreed naming convention. Do not change the recognized names or conditions for Aged Brie, Backstage passes, or Sulfuras.

An explicit item type or property would require changing `Item` and is out of scope. Matching only one full Conjured name would fail to cover the category.

### Verify the behavior with focused xUnit cases

Add focused tests for positive `SellIn`, the zero boundary, already-expired items, quality at or near zero, and the one-step `SellIn` decrement. Keep existing tests and approval snapshots in place; add regression coverage for ordinary and special items as needed to demonstrate unchanged behavior.

## Risks / Trade-offs

- [A classification condition could accidentally affect special items] → Apply the prefix rule only in the ordinary-item deterioration branch; retain the existing exact-name special cases.
- [Applying the multiplier at only one deterioration point would yield the wrong expired rate] → Test both the regular and post-expiration stages, including `SellIn == 0`.
- [A larger refactor could alter existing boundary behavior] → Keep the change local to ordinary-item quality loss and preserve the current update order.

## Migration Plan

No data migration or deployment step is required. Add regression tests, implement the localized behavior, then run the targeted xUnit tests and the existing test suite. Do not alter unrelated pre-existing tests as part of this change.

## Open Questions

None. The Conjured name prefix and scope have been confirmed.
