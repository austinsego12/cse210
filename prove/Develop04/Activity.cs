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

    // Displays a rotating spinner animation for a given number of seconds
public void ShowSpinner(int seconds)
{
    string[] spinner = { "|", "/", "-", "\\" };  // characters for spinner effect
    DateTime endTime = DateTime.Now.AddSeconds(seconds);
    int i = 0;

    while (DateTime.Now < endTime)
    {
        Console.Write(spinner[i]);
        Thread.Sleep(200);         // controls speed of spin
        Console.Write("\b \b");    // backspace, erase, and overwrite character
        i = (i + 1) % spinner.Length;
    }
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
