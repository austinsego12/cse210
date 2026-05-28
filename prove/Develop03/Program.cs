using System;

class Program
{
    static void Main(string[] args)
    {

        Scripture scripture = new Scripture(
            "Proverbs",
            3,
            5,
            6,
            "Trust in the Lord with all thine heart and lean not unto thine own understanding"
        );

        string userInput = "";

        while (userInput != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();

            Console.WriteLine(scripture.Display());
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue or type 'quit' to finish:");

            userInput = Console.ReadLine();

            if (userInput != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }

        Console.Clear();
        Console.WriteLine(scripture.Display());
        Console.WriteLine();
        Console.WriteLine("Program ended.");
    }
}