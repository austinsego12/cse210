using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _items;

    // Constructor
    public ListingActivity(string name, string description) : base(name, description)
    {
        _items = new List<string>();
    }

    // Override Run method
    public override void Run()
    {
        DisplayStart();
        Console.WriteLine("\nList as many positive things as you can!");
        Console.WriteLine("Begin listing...");

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string item = Console.ReadLine();
            _items.Add(item);
        }

        ShowList();
        DisplayEnd();
    }

    public void ListItems()
    {
        foreach (string item in _items)
        {
            Console.WriteLine($"- {item}");
        }
    }

    public void ShowList()
    {
        Console.WriteLine($"\nYou listed {_items.Count} items:");
        ListItems();
    }
}
