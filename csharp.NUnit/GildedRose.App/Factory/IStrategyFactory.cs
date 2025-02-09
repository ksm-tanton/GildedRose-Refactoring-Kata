using GildedRose.Domain.Inventory.Strategy;
using GildedRose.Domain.Models;

namespace GildedRose.App.Factory
{
    public interface IStrategyFactory
    {
        IStrategy GetUpdateStrategy(Item item);
    }
}
