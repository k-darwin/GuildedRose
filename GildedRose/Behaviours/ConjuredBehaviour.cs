namespace GildedRoseKata.Behaviours;

public class ConjuredBehaviour : IItemBehaviour
{
    public void Update(Item item)
    {
        //"Conjured" items degrade in Quality twice as fast as normal items
        if (item.Quality > 0)
        {
            item.Quality -= 2;
        }
        
        item.SellIn--;

        if (item.SellIn < 0 && item.Quality > 0)
        {
            item.Quality -= 2;
        }

        if (item.Quality < 0)
        {
            item.Quality = 0;
        }
    }
}