using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void foo()
    {
        IList<Item> items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(items);
        app.UpdateQuality();
        Assert.Equal("foo", items[0].Name);
        Assert.Equal(-1, items[0].SellIn);
        Assert.Equal(0, items[0].Quality);
    }

    [Fact]
    public void ConjuredItemLosesTwoQualityPointsBeforeExpiration()
    {
        Item item = UpdateItem("Conjured Mana Cake", 3, 6);

        Assert.Equal(4, item.Quality);
        Assert.Equal(2, item.SellIn);
    }

    [Theory]
    [InlineData(0, 6, 2, -1)]
    [InlineData(-1, 6, 2, -2)]
    public void ConjuredItemAtOrPastExpirationLosesFourQualityPoints(int sellIn, int quality, int expectedQuality, int expectedSellIn)
    {
        Item item = UpdateItem("Conjured Mana Cake", sellIn, quality);

        Assert.Equal(expectedQuality, item.Quality);
        Assert.Equal(expectedSellIn, item.SellIn);
    }

    [Fact]
    public void ConjuredQualityDoesNotBecomeNegative()
    {
        Item item = UpdateItem("Conjured Mana Cake", 0, 2);

        Assert.Equal(0, item.Quality);
    }

    [Fact]
    public void DifferentConjuredNamesReceiveAcceleratedDeterioration()
    {
        Item item = UpdateItem("Conjured Dark Blade", 5, 10);

        Assert.Equal(8, item.Quality);
        Assert.Equal(4, item.SellIn);
    }

    [Fact]
    public void ExistingItemCategoriesRetainTheirUpdateBehavior()
    {
        IList<Item> items = new List<Item>
        {
            new Item { Name = "Elixir of the Mongoose", SellIn = 3, Quality = 6 },
            new Item { Name = "Aged Brie", SellIn = 3, Quality = 6 },
            new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 },
            new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }
        };
        GildedRose app = new GildedRose(items);

        app.UpdateQuality();

        Assert.Equal(5, items[0].Quality);
        Assert.Equal(2, items[0].SellIn);
        Assert.Equal(7, items[1].Quality);
        Assert.Equal(2, items[1].SellIn);
        Assert.Equal(22, items[2].Quality);
        Assert.Equal(9, items[2].SellIn);
        Assert.Equal(80, items[3].Quality);
        Assert.Equal(0, items[3].SellIn);
    }

    private static Item UpdateItem(string name, int sellIn, int quality)
    {
        IList<Item> items = new List<Item> { new Item { Name = name, SellIn = sellIn, Quality = quality } };
        GildedRose app = new GildedRose(items);

        app.UpdateQuality();

        return items[0];
    }
}