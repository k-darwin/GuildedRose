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
        private readonly Item _backstagePasses;
        private readonly Item _sulfuras;
        private readonly Item _conjuredItem;

        public GildedRoseTest()
        {
            _regularItem = new Item { Name = "normal", SellIn = 15, Quality = 20 };
            _agedBrie = new Item { Name = "Aged Brie", SellIn = 15, Quality = 20 };
            _backstagePasses = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 };
            _sulfuras = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 };
            _conjuredItem = new Item { Name = "Conjured", SellIn = 15, Quality = 20 };

            _gildedRose = new GildedRose(new List<Item> { _regularItem, _agedBrie, _backstagePasses, _sulfuras, _conjuredItem});
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
        
        [Fact]
        public void UpdateQuality_BackstagePasses_QualityIncreasesSellInDecreases()
        {
            _gildedRose.UpdateQuality();

            Assert.Equal(21, _backstagePasses.Quality);
            Assert.Equal(14, _backstagePasses.SellIn);
        }
        
        [Fact]
        public void UpdateQuality_Sulfuras_QualityAndSellInUnchanged()
        {
            _gildedRose.UpdateQuality();

            Assert.Equal(80, _sulfuras.Quality);
            Assert.Equal(5, _sulfuras.SellIn);
        }
        
        [Fact]
        public void UpdateQuality_QualityIsNeverNegative()
        {
            _regularItem.Quality = 0;
            _gildedRose.UpdateQuality();

            Assert.Equal(0, _regularItem.Quality);
        }
        
        [Fact]
        public void UpdateQuality_QualityNeverMoreThan50()
        {
            _agedBrie.Quality = 50;
            _gildedRose.UpdateQuality();

            Assert.Equal(50, _agedBrie.Quality);
        }
        
        [Fact]
        public void UpdateQuality_BackstagePassesAfterConcert_QualityDropsToZero()
        {
            _backstagePasses.SellIn = 0;
            _gildedRose.UpdateQuality();

            Assert.Equal(0, _backstagePasses.Quality);
        }
        
        [Fact]
        public void UpdateQuality_ConjuredItem_QualityDecreasesTwiceAsFast()
        {
            _gildedRose.UpdateQuality();

            Assert.Equal(18, _conjuredItem.Quality);
        }
    }
}
