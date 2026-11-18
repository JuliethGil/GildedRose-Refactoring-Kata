## 1. Analyze Existing Implementation

- [x] 1.1 Review the current `GildedRose.UpdateQuality()` implementation.
- [x] 1.2 Identify the existing update rules for each item category.
- [x] 1.3 Identify duplicated conditions and responsibilities that can be extracted into private methods.
- [x] 1.4 Identify expiration boundaries and operation ordering that must remain unchanged.

## 2. Refactor Update Logic

- [x] 2.1 Simplify `UpdateQuality()` by keeping it as the main coordinator of item updates.
- [x] 2.2 Extract private methods to identify and handle special item categories.
- [x] 2.3 Separate quality degradation and quality improvement logic.
- [x] 2.4 Extract the logic responsible for applying additional quality degradation after expiration.
- [x] 2.5 Separate `SellIn` updates from quality updates where appropriate.
- [x] 2.6 Preserve the existing quality boundaries and special item rules.

## 3. Preserve Existing Behavior

- [x] 3.1 Preserve normal item update behavior.
- [x] 3.2 Preserve Aged Brie update behavior.
- [x] 3.3 Preserve Backstage passes update behavior.
- [x] 3.4 Preserve Sulfuras immutable behavior.
- [x] 3.5 Preserve Conjured accelerated quality degradation.
- [x] 3.6 Preserve the existing behavior at expiration boundaries.

## 4. Validate Refactoring

- [x] 4.1 Run the complete xUnit test suite.
- [x] 4.2 Run the existing Approval Tests.
- [x] 4.3 Verify that no expected test snapshots require modification.
- [x] 4.4 Review the final implementation to ensure that responsibilities are clearly separated.
- [x] 4.5 Confirm that `Item.cs` and other language implementations remain unchanged.