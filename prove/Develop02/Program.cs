using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity and exceeding requirements:
        // I added a mood and rating feature to each journal entry.
        // This helps the user track not only what happened, but also how they felt that day.
        // I also added a search by mood option so the user can review entries connected to a certain feeling.
        // The save and load system encodes each field so commas, pipes, and special characters in the journal entry do not break the file.

        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string choice = "";

        while (choice != "6")
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Search by Mood");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();

                Console.WriteLine();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                Console.Write("What mood best describes today? ");
                string mood = Console.ReadLine();

                Console.Write("Rate your day from 1 to 10: ");
                string ratingText = Console.ReadLine();

                int rating = 0;
                int.TryParse(ratingText, out rating);

                string date = DateTime.Now.ToShortDateString();

                Entry entry = new Entry(date, prompt, response, mood, rating);
                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();

                journal.SaveToFile(fileName);
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string fileName = Console.ReadLine();

                journal.LoadFromFile(fileName);
            }
            else if (choice == "5")
            {
                Console.Write("What mood would you like to search for? ");
                string mood = Console.ReadLine();

                journal.SearchByMood(mood);
            }
            else if (choice == "6")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Please choose a valid option.");
            }
        }
    }
}