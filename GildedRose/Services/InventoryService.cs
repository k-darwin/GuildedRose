using System;
using System.Collections.Generic;

namespace GildedRoseKata.Services;

public class InventoryService(IEnumerable<Item> items)
{
    public void RunSimulation(int numberOfDays)
    {
        for (var day = 0; day < numberOfDays; day++)
        {
            PrintDay(day);
            UpdateQuality();
        }
    }
    
    private void UpdateQuality()
    {
        var app = new GildedRose(items);
        app.UpdateQuality();
    }

    private void PrintDay(int day)
    {
        Console.WriteLine($"-------- day {day} --------");
        Console.WriteLine("name, sellIn, quality");
        foreach (var item in items)
        {
            Console.WriteLine($"{item.Name}, {item.SellIn}, {item.Quality}");
        }
        Console.WriteLine();
    }
}