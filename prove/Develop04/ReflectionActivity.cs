using System;
using System.Collections.Generic;

public class ReflectionActivity : Activity
{
    private List<string> _questions;

    // Constructor
    public ReflectionActivity(string name, string description) : base(name, description)
    {
        _questions = new List<string>
        {
            "Think of a time you helped someone in need.",
            "Recall a moment you felt proud of yourself.",
            "Remember a challenge you overcame recently."
        };
    }

    // Override Run method
    public override void Run()
    {
        DisplayStart();
        string question = AskQuestion();
        Console.WriteLine($"\nConsider this: {question}");
        Console.WriteLine("Reflect on this for a moment...");
        ShowSpinner(GetDuration());
        DisplayEnd();
    }

    public void Reflect()
    {
        Console.WriteLine("Focus on your thoughts and breathing...");
    }

    public string AskQuestion()
    {
        Random random = new Random();
        int index = random.Next(_questions.Count);
        return _questions[index];
    }
}
