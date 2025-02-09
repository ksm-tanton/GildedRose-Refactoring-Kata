using System.Collections.Generic;
using GildedRose.Domain.Models;

namespace GildedRoseKata.UI
{
    public interface IConsoleUI
    {
        void WriteItem(IList<Item> items, int day);
    }
}
