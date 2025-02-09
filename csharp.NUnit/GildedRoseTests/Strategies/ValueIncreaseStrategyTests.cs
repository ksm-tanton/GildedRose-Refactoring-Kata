using GildedRose.Domain.Inventory.Strategy;
using GildedRose.Domain.Models;
using NUnit.Framework;

namespace GildedRose.Tests.Strategies
{
    public class ValueIncreaseStrategyTests
    {
        [TestCase(10, 10, ExpectedResult = 11)]
        [TestCase(5, 10, ExpectedResult = 11)]
        [TestCase(5, 0, ExpectedResult = 1)]
        [TestCase(1, 10, ExpectedResult = 11)]
        [TestCase(0, 10, ExpectedResult = 12)]
        [TestCase(10, 49, ExpectedResult = 50)]
        [TestCase(10, 50, ExpectedResult = 50)]
        [TestCase(-5, 49, ExpectedResult = 50)]
        [TestCase(-5, 10, ExpectedResult = 12)]
        [TestCase(-10, 10, ExpectedResult = 12)]
        [TestCase(-10, 1, ExpectedResult = 3)]
        [TestCase(-10, 0, ExpectedResult = 2)]
        public int UpdateItem_GivenSellInAndQualityParams_QualityIncreasehouldBeCorrect(
            int sellIn,
            int quality
        )
        {
            // Setup
            var item = new Item()
            {
                Name = "Aged Brie",
                Quality = quality,
                SellIn = sellIn,
            };

            // Act
            var strategy = new ValueIncreaseStrategy();
            strategy.UpdateItem(item);

            return item.Quality;
        }
    }
}
