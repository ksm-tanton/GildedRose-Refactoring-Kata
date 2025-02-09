using System;
using GildedRose.Domain.Inventory.Strategy;
using GildedRose.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace GildedRose.App.Factory
{
    public class StrategyFactory : IStrategyFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public StrategyFactory(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public IStrategy GetUpdateStrategy(Item item)
        {
            ArgumentNullException.ThrowIfNull(item);

            return item.Name switch
            {
                Contants.ItemNames.AGED_BRIE => _serviceProvider.GetKeyedService<IStrategy>(
                    Contants.StrategyTypes.VALUE_INCREASE
                ),
                Contants.ItemNames.SULFURAS => _serviceProvider.GetKeyedService<IStrategy>(
                    Contants.StrategyTypes.LEGENDARY
                ),
                Contants.ItemNames.BACKSTAGE_PASS => _serviceProvider.GetKeyedService<IStrategy>(
                    Contants.StrategyTypes.BACKSTAGE_PASS
                ),
                Contants.ItemNames.CONJURED_MANA_CAKE =>
                    _serviceProvider.GetKeyedService<IStrategy>(Contants.StrategyTypes.CONJURED),
                _ => _serviceProvider.GetKeyedService<IStrategy>(Contants.StrategyTypes.GENERIC),
            };
        }
    }
}
