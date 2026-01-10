using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);

        string letter;

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Stretch: determine + or - sign
        string sign = "";
        int lastDigit = grade % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }

        // No A+ grades (only A or A-)
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }

        // No F+ or F- grades (only F)
        if (letter == "F")
        {
            sign = "";
        }

        Console.WriteLine($"Your letter grade is {letter}{sign}.");

        // Core requirement: pass/fail message (70+ passes)
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Keep trying! You can do it next time.");
        }
    }
}
