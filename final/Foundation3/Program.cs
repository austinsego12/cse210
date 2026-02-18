using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Event> events = new List<Event>();

        events.Add(new LectureEvent(
            "AI in Business",
            "A lecture on how AI is changing business operations.",
            "March 10, 2026",
            "6:00 PM",
            new Address("200 Campus Dr", "Rexburg", "ID", "USA"),
            "Dr. Elena Park",
            120
        ));

        events.Add(new ReceptionEvent(
            "Spring Networking Night",
            "Meet and connect with students and local professionals.",
            "April 2, 2026",
            "7:30 PM",
            new Address("55 Event Hall Ln", "Idaho Falls", "ID", "USA"),
            "rsvp@eventmail.com"
        ));

        events.Add(new OutdoorGatheringEvent(
            "Community Picnic",
            "Outdoor picnic with games and food.",
            "May 15, 2026",
            "12:00 PM",
            new Address("1 Riverside Park", "Rexburg", "ID", "USA"),
            "Sunny, 72F"
        ));

        Console.WriteLine("Event Planning\n");

        foreach (Event ev in events)
        {
            Console.WriteLine("STANDARD DETAILS");
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine();

            Console.WriteLine("FULL DETAILS");
            Console.WriteLine(ev.GetFullDetails());
            Console.WriteLine();

            Console.WriteLine("SHORT DETAILS");
            Console.WriteLine(ev.GetShortDetails());
            Console.WriteLine("\n----------------------------\n");
        }
    }
}


