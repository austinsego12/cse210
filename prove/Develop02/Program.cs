using System;

class Program
{
    static void Main(string[] args)
    {
        /*
        This program also saves an optional Mood (1 to 5) and optional Tags for each entry.
        These fields are shown when displaying the journal and are saved and loaded from the file.
        */

        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine() ?? "";
            Console.WriteLine();

            switch (choice.Trim())
            {
                case "1":
                    WriteEntry(journal, promptGenerator);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("What is the filename? ");
                    string loadFilename = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(loadFilename))
                    {
                        journal.LoadFromFile(loadFilename.Trim());
                    }
                    break;

                case "4":
                    Console.Write("What is the filename? ");
                    string saveFilename = Console.ReadLine() ?? "";
                    if (!string.IsNullOrWhiteSpace(saveFilename))
                    {
                        journal.SaveToFile(saveFilename.Trim());
                    }
                    break;

                case "5":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Please enter a number from 1 to 5.");
                    break;
            }
        }
    }

    private static void WriteEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string date = DateTime.Now.ToShortDateString();
        string prompt = promptGenerator.GetRandomPrompt();

        Console.WriteLine(prompt);
        Console.Write("> ");
        string entryText = Console.ReadLine() ?? "";

        string mood = GetMoodFromUser();
        string tags = GetTagsFromUser();

        Entry entry = new Entry(date, prompt, entryText, mood, tags);
        journal.AddEntry(entry);

        Console.WriteLine("Entry saved.");
    }

    private static string GetMoodFromUser()
    {
        while (true)
        {
            Console.Write("Mood 1 to 5 (press Enter to skip): ");
            string input = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(input))
            {
                return "";
            }

            if (int.TryParse(input.Trim(), out int moodValue))
            {
                if (moodValue >= 1 && moodValue <= 5)
                {
                    return moodValue.ToString();
                }
            }

            Console.WriteLine("Please enter 1, 2, 3, 4, 5, or press Enter to skip.");
        }
    }

    private static string GetTagsFromUser()
    {
        Console.Write("Tags (comma separated, press Enter to skip): ");
        return (Console.ReadLine() ?? "").Trim();
    }
}

