using System;
using System.Collections.Generic;
using GildedRoseKata;
using Microsoft.VisualBasic;
using NUnit.Framework;

namespace GildedRose.Tests;

public class GildedRoseTest
{
    private const string AGED_BRIE = "Aged Brie";
    private const string SULFURAS = "Sulfuras, Hand of Ragnaros";

    [Test]
    public void UpdateQuality_WhenGenenericItemSupplied_AndWithinSellInDays_QualityDecaysBy1()
    {
        // Setup
        var item = new Item
        {
            Name = "Generic Item",
            SellIn = 10,
            Quality = 50,
        };
        var items = new List<Item> { item };
        var app = new GildedRose(items);

        // Act
        for (var i = items[0].SellIn; i > 0; --i)
        {
            var preQuality = items[0].Quality;

            app.UpdateQuality();

            // Assert
            Assert_QualityHasDecayed(items[0], preQuality);
            Assert_QualityHasNotExceededMax(items[0]);
        }
    }

    [Test]
    public void UpdateQuality_WhenGenenericItemSupplied_AndAfterSellInDays_QualityDecaysBy2()
    {
        // Setup
        var item = new Item
        {
            Name = "Generic Item",
            SellIn = 10,
            Quality = 50,
        };
        var items = new List<Item> { item };
        var app = new GildedRose(items);

        // Act
        for (var i = items[0].SellIn; i >= 0 - items[0].SellIn; --i)
        {
            var preQuality = item.Quality;

            app.UpdateQuality();

            // Assert
            if (items[0].SellIn < 0)
            {
                Assert_QualityHasDecayed(items[0], preQuality, 2);
                Assert_QualityHasNotExceededMax(items[0]);
            }
        }
    }

    [Test]
    public void UpdateQuality_WhenAgedBrieSupplied_AndWithinSellInDays_QualityDecaysByNegative1()
    {
        // Setup
        var item = new Item
        {
            Name = AGED_BRIE,
            SellIn = 10,
            Quality = 20,
        };
        var items = new List<Item> { item };
        var app = new GildedRose(items);

        // Act
        for (var i = items[0].SellIn; i > 0; --i)
        {
            var preQuality = items[0].Quality;

            app.UpdateQuality();

            // Assert
            Assert_QualityHasDecayed(items[0], preQuality, -1);
            Assert_QualityHasNotExceededMax(items[0]);
        }
    }

    [Test]
    public void UpdateQuality_WhenAgedBrieSupplied_AndAfterSellInDays_QualityDecaysByNegative2()
    {
        // Setup
        var item = new Item
        {
            Name = AGED_BRIE,
            SellIn = 10,
            Quality = 20,
        };
        var items = new List<Item> { item };
        var app = new GildedRose(items);

        // Act
        for (var i = items[0].SellIn; i >= 0 - items[0].SellIn; --i)
        {
            var preQuality = items[0].Quality;

            app.UpdateQuality();

            // Assert

            if (items[0].SellIn < 0)
            {
                Assert_QualityHasDecayed(items[0], preQuality, -2);
                Assert_QualityHasNotExceededMax(items[0]);
            }
        }
    }

    [Test]
    public void UpdateQuality_WhenSulfurasSupplied_QualityDoesNotDecay()
    {
        // Setup
        var item = new Item
        {
            Name = SULFURAS,
            SellIn = 10,
            Quality = 80,
        };
        var items = new List<Item> { item };
        var app = new GildedRose(items);

        // Act
        for (var i = items[0].SellIn; i >= 0 - items[0].SellIn; --i)
        {
            var preQuality = items[0].Quality;

            app.UpdateQuality();

            // Assert

            if (items[0].SellIn < 0)
            {
                Assert_QualityHasNotDecayed(items[0], preQuality);
                Assert_QualityHasNotExceededMax(items[0], 80);
            }
        }
    }

    private static void Assert_QualityHasDecayed(
        Item item,
        int preQuality,
        int decayRate = 1,
        int maxQuality = 50
    )
    {
        Assert.That(
            item.Quality,
            Is.EqualTo(Math.Min(Math.Max(preQuality - decayRate, 0), maxQuality))
        );
    }

    private static void Assert_QualityHasNotDecayed(Item item, int preQuality)
    {
        Assert.That(item.Quality, Is.EqualTo(preQuality));
    }

    private static void Assert_QualityHasNotExceededMax(Item item, int maxQuality = 50)
    {
        Assert.That(item.Quality, Is.LessThanOrEqualTo(maxQuality));
    }
}
