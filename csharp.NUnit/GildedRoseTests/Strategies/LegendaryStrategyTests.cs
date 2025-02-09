using GildedRose.Domain.Inventory.Strategy;
using GildedRose.Domain.Models;
using NUnit.Framework;

namespace GildedRose.Tests.Strategies
{
    public class LegendaryStrategyTests
    {
        [TestCase(10, 10, ExpectedResult = 10)]
        [TestCase(5, 10, ExpectedResult = 10)]
        [TestCase(5, 0, ExpectedResult = 0)]
        [TestCase(1, 10, ExpectedResult = 10)]
        [TestCase(0, 10, ExpectedResult = 10)]
        [TestCase(-5, 10, ExpectedResult = 10)]
        [TestCase(-10, 10, ExpectedResult = 10)]
        [TestCase(-10, 10, ExpectedResult = 10)]
        [TestCase(-10, 1, ExpectedResult = 1)]
        [TestCase(-10, 0, ExpectedResult = 0)]
        public int UpdateItem_GivenSellInAndQualityParams_QualityShouldRemainConstant(
            int sellIn,
            int quality
        )
        {
            // Setup
            var item = new Item()
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = quality,
                SellIn = sellIn,
            };

            // Act
            var strategy = new LegendaryStrategy();
            strategy.UpdateItem(item);

            return item.Quality;
        }
    }
}
