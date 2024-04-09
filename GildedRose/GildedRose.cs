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
                var behavior = GetBehaviorForItem(item);
                behavior.Update(item);
            }
        }

        private static IItemBehaviour GetBehaviorForItem(Item item)
        {
            return item.Name switch
            {
                "Aged Brie" => new AgedBrieBehaviour(),
                "Backstage passes to a TAFKAL80ETC concert" => new BackstagePassBehaviour(),
                "Sulfuras, Hand of Ragnaros" => new SulfurasBehaviour(),
                _ => new DefaultBehaviour()
            };
        }
    }
}