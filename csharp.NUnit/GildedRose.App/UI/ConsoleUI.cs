using System;
using System.Collections.Generic;
using GildedRose.Domain.Models;

namespace GildedRose.App.UI
{
    public class ConsoleUI : IConsoleUI
    {
        public void WriteItem(IList<Item> items, int day)
        {
            Console.WriteLine("-------- day " + day + " --------");
            Console.WriteLine("name, sellIn, quality");
            for (var j = 0; j < items.Count; j++)
            {
                Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
            }
            Console.WriteLine("");
        }
    }
}
