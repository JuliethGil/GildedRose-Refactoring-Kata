# Gilded Rose Update Logic Specification

## Purpose

Define the existing behavior of the Gilded Rose item update process that must be preserved during the refactoring of the C# xUnit implementation.

The refactoring must improve code organization without changing the observable behavior of any item category.

## ADDED Requirements

### Requirement: Normal Items Quality Degradation

The system SHALL decrease the quality of normal items by one point per day.

When an item's `SellIn` value is zero or negative at the beginning of the update, the quality degradation SHALL be applied twice.

Quality SHALL never become negative.

#### Scenario: Normal item before expiration

- GIVEN a normal item with `SellIn` greater than zero and `Quality` greater than zero
- WHEN the item is updated
- THEN its `Quality` SHALL decrease by one point
- AND its `SellIn` SHALL decrease by one point

#### Scenario: Normal item at expiration

- GIVEN a normal item with `SellIn` equal to zero
- WHEN the item is updated
- THEN its `Quality` SHALL decrease by two points
- AND its `SellIn` SHALL become negative one

### Requirement: Aged Brie Quality Improvement

The system SHALL increase the quality of Aged Brie by one point per day.

After expiration, its quality SHALL increase by two points per day.

Quality SHALL never exceed fifty.

#### Scenario: Aged Brie before expiration

- GIVEN an Aged Brie item with `SellIn` greater than zero and `Quality` below fifty
- WHEN the item is updated
- THEN its `Quality` SHALL increase by one point
- AND its `SellIn` SHALL decrease by one point

#### Scenario: Aged Brie after expiration

- GIVEN an Aged Brie item with `SellIn` equal to zero
- WHEN the item is updated
- THEN its `Quality` SHALL increase by two points
- AND its `SellIn` SHALL become negative one

### Requirement: Backstage Passes Quality Improvement

The system SHALL increase the quality of Backstage passes according to the remaining days until the concert.

- Quality increases by one point when more than ten days remain.
- Quality increases by two points when ten days or fewer remain.
- Quality increases by three points when five days or fewer remain.
- Quality becomes zero after the concert.

Quality SHALL never exceed fifty.

#### Scenario: Backstage pass more than ten days before the concert

- GIVEN a Backstage pass with `SellIn` greater than ten
- WHEN the item is updated
- THEN its `Quality` SHALL increase by one point

#### Scenario: Backstage pass ten days or fewer before the concert

- GIVEN a Backstage pass with `SellIn` between six and ten
- WHEN the item is updated
- THEN its `Quality` SHALL increase by two points

#### Scenario: Backstage pass five days or fewer before the concert

- GIVEN a Backstage pass with `SellIn` between zero and five
- WHEN the item is updated
- THEN its `Quality` SHALL increase by three points

#### Scenario: Backstage pass after the concert

- GIVEN a Backstage pass with `SellIn` equal to zero
- WHEN the item is updated
- THEN its `Quality` SHALL become zero
- AND its `SellIn` SHALL become negative one

### Requirement: Sulfuras Immutable Properties

Sulfuras SHALL never decrease or increase in quality.

Its `SellIn` value SHALL remain unchanged.

#### Scenario: Sulfuras update

- GIVEN a Sulfuras item
- WHEN the item is updated
- THEN its `Quality` SHALL remain unchanged
- AND its `SellIn` SHALL remain unchanged

### Requirement: Conjured Items Quality Degradation

The system SHALL decrease the quality of Conjured items by two points per day.

After expiration, their quality degradation SHALL be applied twice, resulting in a decrease of four points per day.

Quality SHALL never become negative.

#### Scenario: Conjured item before expiration

- GIVEN a Conjured item with `SellIn` greater than zero and `Quality` greater than zero
- WHEN the item is updated
- THEN its `Quality` SHALL decrease by two points
- AND its `SellIn` SHALL decrease by one point

#### Scenario: Conjured item at expiration

- GIVEN a Conjured item with `SellIn` equal to zero
- WHEN the item is updated
- THEN its `Quality` SHALL decrease by four points
- AND its `SellIn` SHALL become negative one

### Requirement: Update Order Preservation

The refactoring SHALL preserve the existing order of operations when updating `Quality` and `SellIn`.

The resulting behavior for items at expiration boundaries SHALL remain unchanged.

#### Scenario: Item expiration boundary

- GIVEN an item whose `SellIn` value is zero before an update
- WHEN the item is updated
- THEN the resulting `Quality` and `SellIn` values SHALL match the existing implementation's behavior

### Requirement: Refactoring Behavior Preservation

The refactoring SHALL preserve the observable behavior of all existing item categories.

The existing unit tests and Approval Tests SHALL continue to pass without modifying their expected results.

#### Scenario: Existing behavior is preserved after refactoring

- GIVEN the existing Gilded Rose implementation and its established business rules
- WHEN the refactored implementation updates the items
- THEN all item categories SHALL produce the same results as the previous implementation
- AND all existing unit tests and Approval Tests SHALL pass without modifying their expected results.