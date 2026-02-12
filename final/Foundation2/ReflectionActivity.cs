using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you did something really hard.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you overcame fear.",
        "Think of a time when you stood up for what was right."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "What did you learn about yourself?",
        "How did you feel when it was over?",
        "How can you use this lesson in the future?"
    };

    private Random _random = new Random();

    public ReflectionActivity()
        : base("Reflection Activity", "This activity will help you reflect on moments of strength and growth.")
    {
    }

    public void Run()
    {
        DisplayStartMessage();

        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();
        Console.WriteLine($"--- {GetRandomPrompt()} ---");
        Console.WriteLine();
        Console.WriteLine("When you are ready, press Enter to begin.");
        Console.ReadLine();

        int duration = GetDuration();
        int elapsed = 0;

        while (elapsed < duration)
        {
            string question = GetRandomQuestion();
            Console.WriteLine();
            Console.Write(question + " ");
            Spinner(6);

            elapsed += 6;
        }

        DisplayEndMessage();
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        return _questions[_random.Next(_questions.Count)];
    }
}

