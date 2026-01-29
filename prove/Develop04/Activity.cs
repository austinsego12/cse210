using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    // Constructor
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Start message
    public void DisplayStart()
    {
        Console.WriteLine($"\nWelcome to the {_name} Activity!");
        Console.WriteLine(_description);
        Console.Write("\nHow long would you like to do this activity (in seconds)? ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    // End message
    public void DisplayEnd()
    {
        Console.WriteLine("\nWell done!");
        Console.WriteLine($"You completed {_duration} seconds of the {_name} Activity.");
        ShowSpinner(3);
    }

    // Simple spinner animation
    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    // Duration accessor
    public int GetDuration()
    {
        return _duration;
    }

    // Virtual Run method (to be overridden)
    public virtual void Run()
    {
        // Placeholder to be overridden by derived classes
    }
}
