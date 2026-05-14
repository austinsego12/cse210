using System;

class Program
{
    static void Main(string[] args)
{
    // Creativity and exceeding requirements:
    // I made this journal more personal by adding a mood and daily rating feature.
    // I also included a Search by Mood option so I can look back at entries based on how I was feeling.
    // I wanted the journal to feel more useful for real life, especially for reflecting on family, faith, gratitude, and personal growth.
    // The save and load system also encodes the entry fields so special characters do not break the saved file.

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