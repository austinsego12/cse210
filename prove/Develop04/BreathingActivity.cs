using System;

public class BreathingActivity : Activity
{
    private int _breathCount;

    // Constructor
    public BreathingActivity(string name, string description) : base(name, description)
    {
        _breathCount = 0;
    }

    // Override Run method
    public override void Run()
    {
        DisplayStart();
        int duration = GetDuration();
        DateTime endTime = DateTime.Now.AddSeconds(duration);

        while (DateTime.Now < endTime)
        {
            BreatheIn();
            BreatheOut();
            _breathCount++;
        }

        Console.WriteLine($"\nYou completed {_breathCount} breathing cycles!");
        DisplayEnd();
    }

    public void BreatheIn()
    {
        Console.Write("\nBreathe in...");
        ShowSpinner(3);
    }

    public void BreatheOut()
    {
        Console.Write("Now breathe out...");
        ShowSpinner(3);
    }
}
