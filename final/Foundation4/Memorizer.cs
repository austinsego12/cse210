using System;

public class Memorizer
{
    private Scripture _scripture;

    public Memorizer(Scripture scripture)
    {
        _scripture = scripture;
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(_scripture.Display());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide words, or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.Trim().ToLower() == "quit")
            {
                break;
            }

            _scripture.HideRandomWords(3);

            if (_scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(_scripture.Display());
                Console.WriteLine();
                Console.WriteLine("All words are hidden. Program complete.");
                break;
            }
        }
    }
}
