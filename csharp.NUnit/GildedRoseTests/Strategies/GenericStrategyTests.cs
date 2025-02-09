using GildedRose.Domain.Inventory.Strategy;
using GildedRose.Domain.Models;
using NUnit.Framework;

namespace GildedRose.Tests.Strategies
{
    public class GenericStrategyTests
    {
        [TestCase(10, 10, ExpectedResult = 9)]
        [TestCase(5, 10, ExpectedResult = 9)]
        [TestCase(5, 0, ExpectedResult = 0)]
        [TestCase(1, 10, ExpectedResult = 9)]
        [TestCase(0, 10, ExpectedResult = 8)]
        [TestCase(-5, 10, ExpectedResult = 8)]
        [TestCase(-10, 10, ExpectedResult = 8)]
        [TestCase(-10, 1, ExpectedResult = 0)]
        [TestCase(-10, 0, ExpectedResult = 0)]
        public int UpdateItem_GivenSellInAndQualityParams_QualityDecreaseShouldBeCorrect(
            int sellIn,
            int quality
        )
        {
            // Setup
            var item = new Item()
            {
                Name = "Generic Item",
                Quality = quality,
                SellIn = sellIn,
            };

            // Act
            var strategy = new GenericStrategy();
            strategy.UpdateItem(item);

            return item.Quality;
        }
    }
}
