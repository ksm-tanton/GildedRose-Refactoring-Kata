using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using GildedRose.App.App_Start;
using GildedRose.App.Factory;
using GildedRose.Domain.Models;
using GildedRoseKata.UI;

namespace GildedRoseKata;

public class Program
{
    private readonly IStrategyFactory _strategyFactory;
    private readonly IConsoleUI _consoleUI;
    private IList<Item> Items;

    public Program(IStrategyFactory strategyFactory, IConsoleUI consoleUI)
    {
        _strategyFactory = strategyFactory;
        _consoleUI = consoleUI;

        PopulateInventory();
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("OMGHAI!");

        int days = 2;
        if (args.Length > 0)
        {
            days = int.Parse(args[0]) + 1;
        }

        var bootstrapper = new Bootstrap();

        var app = new Program(
            bootstrapper.GetService<IStrategyFactory>(),
            bootstrapper.GetService<IConsoleUI>()
        );

        app.ExecuteForDays(days);
    }

    public void ExecuteForDays(int days)
    {
        for (var i = 0; i < days; i++)
        {
            _consoleUI.WriteItem(Items, i);
            Update();
        }
    }

    private void PopulateInventory()
    {
        Items =
        [
            new Item
            {
                Name = "+5 Dexterity Vest",
                SellIn = 10,
                Quality = 20,
            },
            new Item
            {
                Name = "Aged Brie",
                SellIn = 2,
                Quality = 0,
            },
            new Item
            {
                Name = "Elixir of the Mongoose",
                SellIn = 5,
                Quality = 7,
            },
            new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 0,
                Quality = 80,
            },
            new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = -1,
                Quality = 80,
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 15,
                Quality = 20,
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 49,
            },
            new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 49,
            },
            new Item
            {
                Name = "Conjured Mana Cake",
                SellIn = 3,
                Quality = 6,
            },
        ];
    }

    private void Update()
    {
        foreach (var item in Items)
        {
            var strategy = _strategyFactory.GetUpdateStrategy(item);
            strategy.UpdateItem(item);
        }
    }
}
