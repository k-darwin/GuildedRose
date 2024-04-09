namespace GildedRoseKata.Behaviours;

public class DefaultBehaviour : IItemBehaviour
{
    public void Update(Item item)
    {
        if (item.Quality > 0)
        {
            item.Quality -= 2;
        }

        item.SellIn--;

        if (item.SellIn < 0 && item.Quality > 0)
        {
            item.Quality -= 2;
        }
    }
}