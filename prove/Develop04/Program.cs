using System;
using System.Threading;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("--------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity breathing = new BreathingActivity(
                    "Breathing",
                    "This activity helps you relax by guiding you through slow breathing exercises."
                );
                breathing.Run();
            }
            else if (choice == "2")
            {
                ReflectionActivity reflection = new ReflectionActivity(
                    "Reflection",
                    "This activity helps you reflect on meaningful experiences."
                );
                reflection.Run();
            }
            else if (choice == "3")
            {
                ListingActivity listing = new ListingActivity(
                    "Listing",
                    "This activity helps you focus on positive things in your life."
                );
                listing.Run();
            }
            else if (choice == "4")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
                Thread.Sleep(1500);
            }
        }
    }
}
