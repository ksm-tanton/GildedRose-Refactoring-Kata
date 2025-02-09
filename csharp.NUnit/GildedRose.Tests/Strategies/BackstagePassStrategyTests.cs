using GildedRose.Domain.Inventory.Strategy;
using GildedRose.Domain.Models;
using NUnit.Framework;

namespace GildedRose.Tests.Strategies
{
    public class BackstagePassStrategyTests
    {
        [TestCase(15, 10, ExpectedResult = 11)]
        [TestCase(11, 10, ExpectedResult = 12)]
        [TestCase(10, 10, ExpectedResult = 12)]
        [TestCase(6, 10, ExpectedResult = 13)]
        [TestCase(5, 10, ExpectedResult = 13)]
        [TestCase(5, 0, ExpectedResult = 3)]
        [TestCase(1, 10, ExpectedResult = 13)]
        [TestCase(0, 10, ExpectedResult = 0)]
        [TestCase(15, 49, ExpectedResult = 50)]
        [TestCase(15, 50, ExpectedResult = 50)]
        [TestCase(10, 49, ExpectedResult = 50)]
        [TestCase(5, 48, ExpectedResult = 50)]
        [TestCase(-5, 10, ExpectedResult = 0)]
        [TestCase(-10, 10, ExpectedResult = 0)]
        [TestCase(-10, 10, ExpectedResult = 0)]
        [TestCase(-10, 1, ExpectedResult = 0)]
        [TestCase(-10, 0, ExpectedResult = 0)]
        public int UpdateItem_GivenSellInAndQualityParams_QualityChangeShouldBeCorrect(
            int sellIn,
            int quality
        )
        {
            // Setup
            var item = new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = quality,
                SellIn = sellIn,
            };

            // Act
            var strategy = new BackstagePassStrategy();
            strategy.UpdateItem(item);

            return item.Quality;
        }
    }
}
