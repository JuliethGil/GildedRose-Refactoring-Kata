## 1. Add xUnit behavior coverage

- [x] 1.1 Add a test showing a `Conjured ` item loses two quality points while `SellIn` is positive and `SellIn` decreases once.
- [x] 1.2 Add tests for `SellIn` equal to zero and already-expired items, verifying four-point deterioration.
- [x] 1.3 Add a test proving Conjured quality does not drop below zero.
- [x] 1.4 Add regression coverage for ordinary items, Aged Brie, Backstage passes, and Sulfuras without replacing existing tests.
- [x] 1.5 Add a test verifying that different item names beginning with `Conjured ` receive accelerated deterioration.

## 2. Implement Conjured deterioration

- [x] 2.1 Update ordinary-item quality deterioration in `GildedRose.UpdateQuality` to use two-point loss for names beginning with `Conjured ` at each existing deterioration stage.
- [x] 2.2 Preserve the existing `SellIn` update order, quality floor, special-item rules, and unchanged `Item` class.

## 3. Validate the change

- [x] 3.1 Run the focused Conjured xUnit tests and verify their boundary cases.
- [x] 3.2 Run the full C# xUnit test suite and review failures without modifying unrelated or pre-existing tests.
- [x] 3.3 Confirm the implementation and test changes are limited to `csharp.xUnit`.
- [x] 3.4 Verify approval snapshots: `ApprovalTest.ThirtyDays.verified.txt` was intentionally updated for the Conjured behavior; no unrelated approval snapshots were modified; the pre-existing `ApprovalTest.Foo` failure was preserved and its snapshot was not updated; the accidentally generated BOM-only `ApprovalTest.Foo.verified.txt` file was removed.
- [x] 3.5 Record and compare pre-existing test failures before and after implementation, identifying any regressions introduced by the change.
