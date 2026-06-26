using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static List<BaseGoal> _goals = new List<BaseGoal>();
    private static int _score = 0;

    static void Main(string[] args)
    {

        string choice = "";

        while (choice != "6")
        {
            DisplayMenu();
            choice = Console.ReadLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                DisplayGoals();
            }
            else if (choice == "3")
            {
                SaveGoals();
            }
            else if (choice == "4")
            {
                LoadGoals();
            }
            else if (choice == "5")
            {
                RecordEvent();
            }
            else if (choice == "6")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine("Please choose a valid option.");
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine();
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine();
        Console.WriteLine("Menu Options:");
        Console.WriteLine("  1. Create New Goal");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Save Goals");
        Console.WriteLine("  4. Load Goals");
        Console.WriteLine("  5. Record Event");
        Console.WriteLine("  6. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    static void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string goalType = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        if (goalType == "1")
        {
            SimpleGoal goal = new SimpleGoal(name, description, points);
            _goals.Add(goal);

            Console.WriteLine("Simple goal created!");
        }
        else if (goalType == "2")
        {
            EternalGoal goal = new EternalGoal(name, description, points);
            _goals.Add(goal);

            Console.WriteLine("Eternal goal created!");
        }
        else if (goalType == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonusPoints = int.Parse(Console.ReadLine());

            ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonusPoints);
            _goals.Add(goal);

            Console.WriteLine("Checklist goal created!");
        }
        else
        {
            Console.WriteLine("Invalid goal type.");
        }
    }

    static void DisplayGoals()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetGoalDetails()}");
        }
    }

    static void RecordEvent()
    {
        Console.WriteLine();

        if (_goals.Count == 0)
        {
            Console.WriteLine("You do not have any goals yet.");
            return;
        }

        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }

        Console.Write("Which goal did you accomplish? ");
        int goalNumber = int.Parse(Console.ReadLine());

        int index = goalNumber - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        int pointsEarned = _goals[index].RecordEvent();
        _score += pointsEarned;

        Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        Console.WriteLine($"You now have {_score} points.");
    }

    static void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);

            foreach (BaseGoal goal in _goals)
            {
                writer.WriteLine(goal.GetSavedData());
            }
        }

        Console.WriteLine("Goals saved.");
    }

    static void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("That file does not exist.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            BaseGoal goal = ParseGoalData(lines[i]);
            _goals.Add(goal);
        }

        Console.WriteLine("Goals loaded.");
    }

    static BaseGoal ParseGoalData(string data)
    {
        string[] parts = data.Split("|");

        string goalType = parts[0];

        if (goalType == "SimpleGoal")
        {
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            bool isComplete = bool.Parse(parts[4]);

            return new SimpleGoal(name, description, points, isComplete);
        }
        else if (goalType == "EternalGoal")
        {
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);

            return new EternalGoal(name, description, points);
        }
        else if (goalType == "ChecklistGoal")
        {
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            int target = int.Parse(parts[4]);
            int bonusPoints = int.Parse(parts[5]);
            int completions = int.Parse(parts[6]);

            return new ChecklistGoal(name, description, points, target, bonusPoints, completions);
        }
        else
        {
            throw new Exception("Unknown goal type found in file.");
        }
    }
}