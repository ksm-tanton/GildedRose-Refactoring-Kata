using System;
using GildedRose.App.Factory;
using GildedRose.Domain.Inventory.Strategy;
using GildedRoseKata.UI;
using Microsoft.Extensions.DependencyInjection;

namespace GildedRose.App.App_Start
{
    public class Bootstrap
    {
        private readonly IServiceCollection _serviceCollection = new ServiceCollection();
        private IServiceProvider _serviceProvider;

        public Bootstrap()
        {
            this.ConfigureServices();
            this.ConfigureServiceProvider();
        }

        public TService GetService<TService>()
        {
            return _serviceProvider.GetService<TService>();
        }

        private void ConfigureServices()
        {
            this._serviceCollection.AddSingleton<IConsoleUI, ConsoleUI>();
            this._serviceCollection.AddSingleton<IStrategyFactory, StrategyFactory>();
            this._serviceCollection.AddKeyedTransient<IStrategy, GenericStrategy>(
                Domain.Models.Contants.StrategyTypes.GENERIC
            );
            this._serviceCollection.AddKeyedTransient<IStrategy, ValueIncreaseStrategy>(
                Domain.Models.Contants.StrategyTypes.VALUE_INCREASE
            );
            this._serviceCollection.AddKeyedTransient<IStrategy, BackstagePassStrategy>(
                Domain.Models.Contants.StrategyTypes.BACKSTAGE_PASS
            );
            this._serviceCollection.AddKeyedTransient<IStrategy, ConjuredStrategy>(
                Domain.Models.Contants.StrategyTypes.CONJURED
            );
            this._serviceCollection.AddKeyedTransient<IStrategy, LegendaryStrategy>(
                Domain.Models.Contants.StrategyTypes.LEGENDARY
            );
        }

        private void ConfigureServiceProvider()
        {
            this._serviceProvider = this._serviceCollection.BuildServiceProvider();
        }
    }
}
