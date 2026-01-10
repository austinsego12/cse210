using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string name = PromptUserName();
        int favoriteNumber = PromptUserNumber();

        int birthYear;
        PromtUserBirthYear(out birthYear);

        int squaredNumber = SquareNumber(favoriteNumber);

        DisplayResult(name, squaredNumber, birthYear);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }

    // Note: function name spelled "PromtUserBirthYear" to match the assignment text
    static void PromtUserBirthYear(out int birthYear)
    {
        Console.Write("Please enter the year you were born: ");
        birthYear = int.Parse(Console.ReadLine());
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(string name, int squaredNumber, int birthYear)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");

        int currentYear = DateTime.Now.Year;
        int ageThisYear = currentYear - birthYear;

        Console.WriteLine($"{name}, you will turn {ageThisYear} this year.");
    }
}
