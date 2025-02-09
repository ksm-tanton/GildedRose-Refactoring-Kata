using GildedRose.Domain.Models;

namespace GildedRose.Domain.Inventory.Strategy
{
    public class GenericStrategy : IStrategy
    {
        public void UpdateItem(Item item)
        {
            item.SellIn--;
            item.Quality -= GetQualityDecrease(item);
        }

        private static int GetQualityDecrease(Item item)
        {
            return Math.Min(item.Quality, item.SellIn >= 0 ? 1 : 2);
        }
    }
}
