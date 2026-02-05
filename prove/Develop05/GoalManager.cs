using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    // Exceed requirements: badges + random celebration messages
    private Random _rng = new Random();
    private HashSet<string> _badgesEarned = new HashSet<string>();
    private int _successfulEventsRecorded = 0;

    private readonly string[] _celebrations =
    {
        "Nice! Keep going!",
        "Big W!",
        "Let’s goooo!",
        "That counts. Keep stacking wins!",
        "Momentum is building!",
        "Quest progress unlocked!",
        "Clean work!",
        "You are actually doing it!"
    };

    private readonly string[] _bigCelebrations =
    {
        "HUGE WIN! You are on fire!",
        "Legend behavior!",
        "That was massive. Keep cooking!",
        "Main character moment!",
        "Elite progress right there!"
    };

    public void Start()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            DisplayPlayerInfo();

            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                CreateGoal();
            }
            else if (choice == "2")
            {
                ListGoalDetails();
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
                running = false;
            }
            else
            {
                Console.WriteLine("Not a valid option. Press Enter to try again.");
                Console.ReadLine();
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Badges: {_badgesEarned.Count}");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Your Goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("  (none yet)");
        }
        else
        {
            for (int i = 0; i < _goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
            }
        }

        if (_badgesEarned.Count > 0)
        {
            Console.WriteLine();
            Console.WriteLine("Badges Earned:");
            foreach (string badge in _badgesEarned)
            {
                Console.WriteLine($"  🏅 {badge}");
            }
        }

        Console.WriteLine();
        Console.Write("Press Enter to continue.");
        Console.ReadLine();
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string typeChoice = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("What is the amount of points associated with this goal? ");
        int points = ReadInt();

        if (typeChoice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (typeChoice == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (typeChoice == "3")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            int target = ReadInt();

            Console.Write("What is the bonus for accomplishing it that many times? ");
            int bonus = ReadInt();

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
        else
        {
            Console.WriteLine("Not a valid goal type. Press Enter to continue.");
            Console.ReadLine();
            return;
        }

        if (_goals.Count == 1)
        {
            AwardBadge("Quest Starter", "Created your first goal");
        }

        Console.WriteLine();
        Console.WriteLine("Goal created. Press Enter to continue.");
        Console.ReadLine();
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet. Press Enter to continue.");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("Select a goal to record an event for:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        Console.Write("Which goal did you accomplish? ");
        int goalIndex = ReadInt() - 1;

        if (goalIndex < 0 || goalIndex >= _goals.Count)
        {
            Console.WriteLine("Not a valid goal number. Press Enter to continue.");
            Console.ReadLine();
            return;
        }

        Goal selectedGoal = _goals[goalIndex];
        bool wasCompleteBefore = selectedGoal.IsComplete();

        int earned = selectedGoal.RecordEvent();
        bool isCompleteNow = selectedGoal.IsComplete();

        Console.WriteLine();

        if (earned <= 0)
        {
            Console.WriteLine("No points earned for that event.");
            Console.WriteLine("That goal might already be complete. Press Enter to continue.");
            Console.ReadLine();
            return;
        }

        _successfulEventsRecorded++;
        _score += earned;

        Console.WriteLine($"You earned {earned} points.");
        Console.WriteLine($"You now have {_score} points.");

        ShowRandomCelebration(earned);

        if (_successfulEventsRecorded == 1)
        {
            AwardBadge("First Win", "Recorded your first event");
        }

        CheckScoreBadges();

        // award badge when a goal becomes complete
        if (!wasCompleteBefore && isCompleteNow)
        {
            AwardBadge("Goal Finisher", $"Completed: {selectedGoal.GetName()}");

            if (selectedGoal is ChecklistGoal)
            {
                AwardBadge("Checklist Champion", "Completed a checklist goal");
                ShowBigCelebration();
            }
            else
            {
                if (_rng.Next(0, 2) == 0)
                {
                    ShowBigCelebration();
                }
            }
        }

        Console.WriteLine();
        Console.Write("Press Enter to continue.");
        Console.ReadLine();
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename to save to? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }

        Console.WriteLine("Saved. Press Enter to continue.");
        Console.ReadLine();
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename to load from? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found. Press Enter to continue.");
            Console.ReadLine();
            return;
        }

        string[] lines = File.ReadAllLines(filename);

        _goals.Clear();
        _score = 0;

        if (lines.Length == 0)
        {
            Console.WriteLine("File was empty. Press Enter to continue.");
            Console.ReadLine();
            return;
        }

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split('|');
            string type = parts[0];

            if (type == "SimpleGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                bool isComplete = bool.Parse(parts[4]);

                _goals.Add(new SimpleGoal(name, description, points, isComplete));
            }
            else if (type == "EternalGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (type == "ChecklistGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                int bonus = int.Parse(parts[4]);
                int target = int.Parse(parts[5]);
                int amountCompleted = int.Parse(parts[6]);

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
            }
        }

        // reset fun stuff for this run (not required to save)
        _badgesEarned.Clear();
        _successfulEventsRecorded = 0;

        if (_goals.Count > 0)
        {
            AwardBadge("Quest Starter", "Loaded goals into your quest");
        }

        CheckScoreBadges();

        Console.WriteLine("Loaded. Press Enter to continue.");
        Console.ReadLine();
    }

    private void CheckScoreBadges()
    {
        if (_score >= 1000) AwardBadge("Bronze Adventurer", "Reached 1000 points");
        if (_score >= 5000) AwardBadge("Silver Adventurer", "Reached 5000 points");
        if (_score >= 10000) AwardBadge("Gold Adventurer", "Reached 10000 points");
    }

    private void AwardBadge(string badgeName, string reason)
    {
        if (_badgesEarned.Add(badgeName))
        {
            Console.WriteLine();
            Console.WriteLine($"🏅 Badge earned: {badgeName}");
            Console.WriteLine(reason);
        }
    }

    private void ShowRandomCelebration(int earned)
    {
        if (earned >= 500)
        {
            ShowBigCelebration();
            return;
        }

        string msg = _celebrations[_rng.Next(_celebrations.Length)];
        Console.WriteLine(msg);
    }

    private void ShowBigCelebration()
    {
        string msg = _bigCelebrations[_rng.Next(_bigCelebrations.Length)];
        Console.WriteLine(msg);
    }

    private int ReadInt()
    {
        while (true)
        {
            string input = Console.ReadLine();
            if (int.TryParse(input, out int value))
            {
                return value;
            }

            Console.Write("Please enter a whole number: ");
        }
    }
}




