using System;
using System.Collections.Generic;

namespace GildedRoseKata;

public class GildedRose
{
    private readonly IList<Item> Items;

    public GildedRose(IList<Item> Items)
    {
        this.Items = Items;
    }

    public void UpdateQuality()
    {
        for (var i = 0; i < Items.Count; i++)
        {
            UpdateItem(Items[i]);
        }
    }

    private static void UpdateItem(Item item)
    {
        if (IsSulfuras(item))
        {
            return;
        }

        UpdateQuality(item);
        UpdateSellIn(item);
        UpdateExpiredItem(item);
    }

    private static void UpdateQuality(Item item)
    {
        if (IsAgedBrie(item))
        {
            IncreaseQuality(item);
            return;
        }

        if (IsBackstagePass(item))
        {
            UpdateBackstagePassQuality(item);
            return;
        }

        DecreaseQuality(item);
    }

    private static void UpdateBackstagePassQuality(Item item)
    {
        if (item.Quality >= 50)
        {
            return;
        }

        IncreaseQuality(item);

        if (item.SellIn < 11)
        {
            IncreaseQuality(item);
        }

        if (item.SellIn < 6)
        {
            IncreaseQuality(item);
        }
    }

    private static void DecreaseQuality(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality = Math.Max(0, item.Quality - GetQualityLoss(item));
        }
    }

    private static void UpdateExpiredItem(Item item)
    {
        if (item.SellIn >= 0)
        {
            return;
        }

        if (IsAgedBrie(item))
        {
            IncreaseQuality(item);
            return;
        }

        if (IsBackstagePass(item))
        {
            item.Quality = 0;
            return;
        }

        DecreaseQuality(item);
    }

    private static void UpdateSellIn(Item item)
    {
        item.SellIn -= 1;
    }

    private static void IncreaseQuality(Item item)
    {
        if (item.Quality < 50)
        {
            item.Quality += 1;
        }
    }

    private static int GetQualityLoss(Item item)
    {
        return IsConjured(item) ? 2 : 1;
    }

    private static bool IsAgedBrie(Item item)
    {
        return item.Name == "Aged Brie";
    }

    private static bool IsBackstagePass(Item item)
    {
        return item.Name == "Backstage passes to a TAFKAL80ETC concert";
    }

    private static bool IsSulfuras(Item item)
    {
        return item.Name == "Sulfuras, Hand of Ragnaros";
    }

    private static bool IsConjured(Item item)
    {
        return item.Name != null && item.Name.StartsWith("Conjured ", StringComparison.Ordinal);
    }
}