using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public int GetScore()
    {
        return _score;
    }

    public void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("Goal Types:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Choose a type: ");
        string choice = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        int points = ReadInt("Points for completion: ", 100);

        Goal goal = null;

        if (choice == "1")
        {
            goal = new SimpleGoal(name, description, points);
        }
        else if (choice == "2")
        {
            goal = new EternalGoal(name, description, points);
        }
        else if (choice == "3")
        {
            int target = ReadInt("How many times to complete? ", 10);
            int bonus = ReadInt("Bonus points when finished: ", 500);
            goal = new ChecklistGoal(name, description, points, target, bonus);
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        _goals.Add(goal);
        Console.WriteLine("Goal created.");
    }

    public void ListGoals()
    {
        Console.WriteLine();
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDisplayString()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Select a goal to record:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        int index = ReadInt("Enter goal number: ", 1) - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid selection.");
            return;
        }

        int earned = _goals[index].RecordEvent();
        _score += earned;

        Console.WriteLine($"You earned {earned} points!");
        Console.WriteLine($"Total Score: {_score}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetSaveString());
            }
        }

        Console.WriteLine("Saved.");
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _goals.Clear();

        if (lines.Length == 0)
        {
            Console.WriteLine("File is empty.");
            return;
        }

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            Goal goal = GoalFactory.FromSaveString(lines[i]);
            if (goal != null)
            {
                _goals.Add(goal);
            }
        }

        Console.WriteLine("Loaded.");
    }

    private int ReadInt(string prompt, int fallback)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int value))
        {
            value = fallback;
            Console.WriteLine($"Invalid input. Defaulting to {fallback}.");
        }

        return value;
    }
}
