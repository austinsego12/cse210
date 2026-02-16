using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine($"Current Score: {manager.GetScore()}");
            Console.WriteLine();
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.CreateGoal();
                    break;
                case "2":
                    manager.ListGoals();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    manager.SaveGoals(Console.ReadLine());
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    manager.LoadGoals(Console.ReadLine());
                    break;
                case "5":
                    manager.RecordEvent();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
