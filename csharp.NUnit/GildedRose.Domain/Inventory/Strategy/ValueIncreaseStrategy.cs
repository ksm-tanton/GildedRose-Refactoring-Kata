using GildedRose.Domain.Models;

namespace GildedRose.Domain.Inventory.Strategy
{
    public class ValueIncreaseStrategy : IStrategy
    {
        private const int _qualityCap = 50;

        public void UpdateItem(Item item)
        {
            item.SellIn--;
            item.Quality += GetQualityIncrease(item);
        }

        private static int GetQualityIncrease(Item item)
        {
            return Math.Min(_qualityCap - item.Quality, item.SellIn >= 0 ? 1 : 2);
        }
    }
}
