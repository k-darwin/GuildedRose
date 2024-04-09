using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    
    public class GildedRoseTest
    {
        private readonly GildedRose _gildedRose;
        private readonly Item _regularItem;
        private readonly Item _agedBrie;

        public GildedRoseTest()
        {
            _regularItem = new Item { Name = "normal", SellIn = 15, Quality = 20 };
            _agedBrie = new Item { Name = "Aged Brie", SellIn = 15, Quality = 20 };

            _gildedRose = new GildedRose(new List<Item> { _regularItem, _agedBrie});
        }
        
        [Fact]
        public void UpdateQuality_NormalItem_QualityAndSellInDecrease()
        {
            _gildedRose.UpdateQuality();

            Assert.Equal(18, _regularItem.Quality);
            Assert.Equal(14, _regularItem.SellIn);
        }
        
        [Fact]
        public void UpdateQuality_AgedBrie_QualityIncreasesSellInDecreases()
        {
            _gildedRose.UpdateQuality();

            Assert.Equal(21, _agedBrie.Quality);
            Assert.Equal(14, _agedBrie.SellIn);
        }
        
    }
}
