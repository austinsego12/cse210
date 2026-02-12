using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing.")
    {
    }

    public void Run()
    {
        DisplayStartMessage();

        int duration = GetDuration();
        int elapsed = 0;

        while (elapsed < duration)
        {
            Console.Write("Breathe in... ");
            Countdown(4);
            Console.WriteLine();

            Console.Write("Breathe out... ");
            Countdown(6);
            Console.WriteLine();

            elapsed += 10;
        }

        DisplayEndMessage();
    }
}
