using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests
{
    public class GildedRoseTest
    {
        [Fact]
        public void UpdateQuality_WithDefaultItems_DecreasesQuality()
        {
            var items = new List<Item> {new() {Name = "item", Quality = 5, SellIn = 5}};
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(3, items[0].Quality);
        }
        
        [Fact]
        public void UpdateQuality_WithDefaultItems_DecreasesSellIn()
        {
            var items = new List<Item> {new() {Name = "item", Quality = 5, SellIn = 5}};
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(4, items[0].SellIn);
        }
        
        [Fact]
        public void UpdateQuality_WithDefaultItems_QualityNeverNegative()
        {
            var items = new List<Item> {new() {Name = "item", Quality = 0, SellIn = 5}};
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(0, items[0].Quality);
        }
        
    }
}
