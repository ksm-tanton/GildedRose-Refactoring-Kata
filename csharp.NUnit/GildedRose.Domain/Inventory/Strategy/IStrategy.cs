using GildedRose.Domain.Models;

namespace GildedRose.Domain.Inventory.Strategy
{
    public interface IStrategy
    {
        void UpdateItem(Item item);
    }
}
