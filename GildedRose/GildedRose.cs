using System;
using System.Collections.Generic;
using GildedRoseKata.Behaviours;

namespace GildedRoseKata
{
    public class GildedRose(IEnumerable<Item> items)
    {
        public void UpdateQuality()
        {
            foreach (var item in items)
            {
                try
                {
                    var behavior = GetBehaviorForItem(item);
                    behavior.Update(item);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An error occurred for item {item.Name}, sellIn: {item.SellIn}, quality: {item.Quality}");
                    Console.WriteLine(e);
                }
            }
        }

        private static IItemBehaviour GetBehaviorForItem(Item item)
        {
            return item.Name switch
            {
                ItemNames.AgedBrie => new AgedBrieBehaviour(),
                ItemNames.BackstagePasses => new BackstagePassBehaviour(),
                ItemNames.Sulfuras => new SulfurasBehaviour(),
                var name when name.StartsWith(ItemNames.Conjured) => new ConjuredBehaviour(),
                _ => new DefaultBehaviour()
            };
        }
    }
}