using System.Collections.Generic;
using GildedRose.Domain.Models;

namespace GildedRose.App.UI
{
    public interface IConsoleUI
    {
        void WriteItem(IList<Item> items, int day);
    }
}
