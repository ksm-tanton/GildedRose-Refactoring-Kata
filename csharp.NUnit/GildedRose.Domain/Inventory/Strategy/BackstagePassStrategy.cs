using GildedRose.Domain.Models;

namespace GildedRose.Domain.Inventory.Strategy
{
    public class BackstagePassStrategy : IStrategy
    {
        private const int _qualityCap = 50;

        public void UpdateItem(Item item)
        {
            item.SellIn--;
            item.Quality += GetQualityIncrease(item);
        }

        private static int GetQualityIncrease(Item item)
        {
            if (item.SellIn < 0)
                return -item.Quality;

            if (item.SellIn <= 10)
            {
                return Math.Min(_qualityCap - item.Quality, item.SellIn <= 5 ? 3 : 2);
            }

            return Math.Min(_qualityCap - item.Quality, 1);
        }
    }
}
