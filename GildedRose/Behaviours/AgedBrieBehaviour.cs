namespace GildedRoseKata.Behaviours;

public class AgedBrieBehaviour : IItemBehaviour
{
    public void Update(Item item)
    {
        item.SellIn--;

        if (item.Quality < 50)
        {
            item.Quality += (item.SellIn < 0) ? 2 : 1;
        }
    }
}