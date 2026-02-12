using System;
using System.Collections.Generic;

public class PromptGenerator
{
    private List<string> _prompts = new List<string>()
    {
        "What made you smile today?",
        "What is something you learned today?",
        "What was the hardest part of your day and why?",
        "What is one thing you are grateful for today?",
        "Who did you help today?",
        "What do you want to do better tomorrow?"
    };

    private Random _random = new Random();

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }
}
