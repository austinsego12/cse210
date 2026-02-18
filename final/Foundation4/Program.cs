using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new RunningActivity("03 Nov 2025", 30, 3.1));     // miles
        activities.Add(new CyclingActivity("10 Nov 2025", 45, 16.0));    // mph
        activities.Add(new SwimmingActivity("20 Nov 2025", 25, 40));     // laps

        Console.WriteLine("Exercise Tracking\n");

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

