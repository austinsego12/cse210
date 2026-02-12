using System;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    protected int GetDuration()
    {
        return _duration;
    }

    protected void SetDurationFromUser()
    {
        Console.Write("Enter duration in seconds: ");
        string input = Console.ReadLine();

        if (!int.TryParse(input, out _duration) || _duration <= 0)
        {
            _duration = 30;
            Console.WriteLine("Invalid input. Defaulting to 30 seconds.");
        }
    }

    protected void DisplayStartMessage()
    {
        Console.WriteLine();
        Console.WriteLine($"Starting {_name}");
        Console.WriteLine(_description);
        Console.WriteLine();
        SetDurationFromUser();
        Console.WriteLine("Get ready...");
        Spinner(3);
        Console.WriteLine();
    }

    protected void DisplayEndMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done.");
        Spinner(2);
        Console.WriteLine($"You completed {_duration} seconds of {_name}.");
        Spinner(2);
        Console.WriteLine();
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected void Spinner(int seconds)
    {
        string[] frames = { "|", "/", "-", "\\" };
        int endTime = Environment.TickCount + (seconds * 1000);
        int index = 0;

        while (Environment.TickCount < endTime)
        {
            Console.Write(frames[index % frames.Length]);
            Thread.Sleep(250);
            Console.Write("\b \b");
            index++;
        }
    }
}
