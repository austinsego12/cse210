using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people you appreciate?",
        "What are your personal strengths?",
        "What are things that make you happy?",
        "What are things you have accomplished recently?"
    };

    private Random _random = new Random();

    public ListingActivity()
        : base("Listing Activity", "This activity will help you list positive things and recognize blessings.")
    {
    }

    public void Run()
    {
        DisplayStartMessage();

        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.Write("You may begin in: ");
        Countdown(5);
        Console.WriteLine();
        Console.WriteLine();

        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        List<string> items = new List<string>();

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(response))
            {
                items.Add(response);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items.");

        DisplayEndMessage();
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }
}
