using System;

class Program
{
    static void Main(string[] args)
    {
        // Choose a reference and scripture text
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.";

        Scripture scripture = new Scripture(reference, text);

        bool finished = false;

        while (!finished)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press Enter to hide more words or type 'quit' to finish: ");

            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) &&
                input.Trim().ToLower() == "quit")
            {
                finished = true;
            }
            else
            {
                if (scripture.IsCompletelyHidden())
                {
                    finished = true;
                }
                else
                {
                    scripture.HideRandomWords(3); // hide a few words each time

                    if (scripture.IsCompletelyHidden())
                    {
                        Console.Clear();
                        Console.WriteLine(scripture.GetDisplayText());
                        finished = true;
                    }
                }
            }
        }
    }
}
