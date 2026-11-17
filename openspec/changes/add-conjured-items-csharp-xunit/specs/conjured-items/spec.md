## ADDED Requirements

### Requirement: Conjured items degrade twice as fast as ordinary items
The C# xUnit implementation SHALL identify an item as Conjured when its name begins with the literal `Conjured ` prefix. On each daily update, a Conjured item SHALL lose two quality points while its `SellIn` value is positive before the update, and four quality points when its `SellIn` value is zero or negative before the update. Its quality SHALL never become negative, and its `SellIn` SHALL decrease by exactly one.

#### Scenario: Conjured item before expiration
- **WHEN** an item named `Conjured Mana Cake` has `SellIn` 3 and `Quality` 6 and is updated
- **THEN** its `Quality` becomes 4 and its `SellIn` becomes 2

#### Scenario: Conjured item reaches zero SellIn
- **WHEN** an item named `Conjured Mana Cake` has `SellIn` 1 and `Quality` 6 and is updated
- **THEN** its `Quality` becomes 4 and its `SellIn` becomes 0

#### Scenario: Conjured item with zero SellIn receives expired deterioration
- **WHEN** an item named `Conjured Mana Cake` has `SellIn` 0 and `Quality` 6 and is updated
- **THEN** its `Quality` becomes 2 and its `SellIn` becomes -1

#### Scenario: Already expired Conjured item
- **WHEN** an item named `Conjured Mana Cake` has `SellIn` -1 and `Quality` 6 and is updated
- **THEN** its `Quality` becomes 2 and its `SellIn` becomes -2

#### Scenario: Conjured quality does not fall below zero
- **WHEN** an item named `Conjured Mana Cake` has `SellIn` 0 and `Quality` 2 and is updated
- **THEN** its `Quality` becomes 0

#### Scenario: Different Conjured item names receive accelerated deterioration
- **WHEN** an item named `Conjured Dark Blade` has `SellIn` 5 and `Quality` 10 and is updated
- **THEN** its `Quality` becomes 8 and its `SellIn` becomes 4

### Requirement: Existing item categories retain their update behavior
Adding Conjured-item handling SHALL NOT change the established quality or `SellIn` updates for ordinary items, Aged Brie, Backstage passes, or Sulfuras.

#### Scenario: Ordinary item retains normal deterioration
- **WHEN** an ordinary item has `SellIn` 3 and `Quality` 6 and is updated
- **THEN** its `Quality` becomes 5 and its `SellIn` becomes 2

#### Scenario: Aged Brie retains increasing quality
- **WHEN** Aged Brie has `SellIn` 3 and `Quality` 6 and is updated
- **THEN** its `Quality` becomes 7 and its `SellIn` becomes 2

#### Scenario: Backstage pass retains its approaching-event increase
- **WHEN** a Backstage pass has `SellIn` 10 and `Quality` 20 and is updated
- **THEN** its `Quality` becomes 22 and its `SellIn` becomes 9

#### Scenario: Sulfuras remains unchanged
- **WHEN** Sulfuras has `SellIn` 0 and `Quality` 80 and is updated
- **THEN** its `Quality` remains 80 and its `SellIn` remains 0