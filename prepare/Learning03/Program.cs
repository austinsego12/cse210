using System;

class Program
{
    static void Main(string[] args)
    {
        // Test the three constructors and representations
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        // Practice using setters and getters with random fractions
        Fraction randomFraction = new Fraction();
        Random rand = new Random();

        for (int i = 1; i <= 20; i++)
        {
            int top = rand.Next(1, 11);     // 1–10
            int bottom = rand.Next(1, 11);  // 1–10, never 0

            randomFraction.SetTop(top);
            randomFraction.SetBottom(bottom);

            Console.WriteLine(
                $"Fraction {i}: string: {randomFraction.GetFractionString()} Number: {randomFraction.GetDecimalValue()}"
            );
        }
    }
}
