## Context

Currently, the `UpdateQuality()` method contains the update rules for all item categories. Its implementation includes multiple levels of nested conditionals and repeated name comparisons, making the logic difficult to understand and maintain.

The goal of this refactoring is to improve the internal organization of the code without changing the observable behavior of the application.

## Goals

- Simplify the `UpdateQuality()` method.
- Separate responsibilities through private methods.
- Reduce duplicated conditions and operations.
- Improve the readability and maintainability of business rules.
- Preserve the existing behavior of all item categories.

## Technical Decisions

### 1. Keep GildedRose as the Coordinator

The `GildedRose` class will remain responsible for iterating through the collection of items and coordinating their updates.

The `UpdateQuality()` method will delegate operations to private methods with specific responsibilities.

### 2. Separate Update Logic

Private methods will be extracted to organize the following responsibilities:

- Identification of special item categories.
- Quality updates according to each category's rules.
- Application of additional quality degradation after expiration.
- `SellIn` updates.
- Enforcement of the allowed `Quality` boundaries.

The final method names and distribution will be established during implementation, ensuring that each method has a cohesive responsibility.

### 3. Preserve Business Rules

The existing rules will be preserved:

- Normal items lose quality daily, and their degradation doubles after expiration.
- Aged Brie increases in quality over time.
- Backstage passes increase in quality as the concert approaches and lose all quality after the concert.
- Sulfuras does not change its quality or sell-in value.
- Conjured items lose quality at twice the rate of normal items.

Quality must remain within the boundaries established by the existing rules.

### 4. Keep Item as a Data Model

The `Item` class will retain its current properties (`Name`, `SellIn`, and `Quality`).

Business rules will not be moved into this class as part of this change, since the goal is to reorganize the existing logic within `GildedRose`.

### 5. Testing Strategy

Existing unit tests and Approval Tests will be used to verify that the refactoring preserves the previous behavior.

Expected test results will not be modified as a consequence of the refactoring.

## Alternatives Considered

### Keep All Logic in UpdateQuality()

This approach is rejected because it preserves the existing readability, nesting, and mixed-responsibility issues.

### Introduce the Strategy Pattern

This approach is deferred at this stage because it would require additional classes and structural complexity that are not necessary to achieve the current goal.

### Introduce Behavior into Item

This approach is rejected for this change because the intention is to keep `Item` as a data model and concentrate the reorganization within `GildedRose`.

## Risks and Mitigations

- **Risk:** Accidentally changing an existing business rule while extracting methods.

  **Mitigation:** Run unit tests and Approval Tests after each modification.

- **Risk:** Changing the order of update operations.

  **Mitigation:** Preserve the current execution order of operations on `Quality` and `SellIn`, especially in expiration scenarios.

## Impact

Changes will be limited to `csharp.xUnit/GildedRose/GildedRose.cs`.

The `Item.cs` class and test projects will retain their current structure.