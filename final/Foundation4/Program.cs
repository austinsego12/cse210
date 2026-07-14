using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        Running running = new Running(
            "03 Nov 2026",
            30,
            3.0
        );

        Cycling cycling = new Cycling(
            "05 Nov 2026",
            45,
            12.0
        );

        Swimming swimming = new Swimming(
            "07 Nov 2026",
            30,
            40
        );

        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}