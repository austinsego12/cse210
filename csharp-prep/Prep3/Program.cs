using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            int magicNumber = randomGenerator.Next(1, 101); // 1 to 100
            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("I have chosen a magic number between 1 and 100.");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                string userInput = Console.ReadLine();
                guess = int.Parse(userInput);
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            Console.WriteLine($"It took you {guessCount} guesses.");

            Console.Write("Do you want to play again? (yes/no) ");
            playAgain = Console.ReadLine();
            Console.WriteLine();
        }
    }
}
