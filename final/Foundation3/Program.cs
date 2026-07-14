using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Event> events = new List<Event>();

        Address lectureAddress = new Address(
            "525 South Center Street",
            "Rexburg",
            "Idaho",
            "USA"
        );

        Lecture lecture = new Lecture(
            "Technology and the Future",
            "A presentation about emerging technology and computer science.",
            "December 10, 2026",
            "6:00 PM",
            lectureAddress,
            "Dr. Sarah Mitchell",
            250
        );

        Address receptionAddress = new Address(
            "1200 Grand Boulevard",
            "St. Louis",
            "Missouri",
            "USA"
        );

        Reception reception = new Reception(
            "Community Celebration Reception",
            "An evening reception for community members and guests.",
            "December 15, 2026",
            "7:00 PM",
            receptionAddress,
            "rsvp@communityevents.com"
        );

        Address outdoorAddress = new Address(
            "5595 Grand Drive",
            "St. Louis",
            "Missouri",
            "USA"
        );

        OutdoorGathering outdoorGathering = new OutdoorGathering(
            "Outdoor Family Festival",
            "A family-friendly outdoor event with food, games, and activities.",
            "December 20, 2026",
            "1:00 PM",
            outdoorAddress,
            "Sunny with a high of 62 degrees."
        );

        events.Add(lecture);
        events.Add(reception);
        events.Add(outdoorGathering);

        foreach (Event eventItem in events)
    {
         Console.WriteLine();
        Console.WriteLine("STANDARD DETAILS");
        Console.WriteLine(eventItem.GetStandardDetails());

        Console.WriteLine();
        Console.WriteLine("FULL DETAILS");
        Console.WriteLine(eventItem.GetFullDetails());

        Console.WriteLine();
        Console.WriteLine("SHORT DESCRIPTION");
        Console.WriteLine(eventItem.GetShortDescription());

        Console.WriteLine();
}
    }
 }