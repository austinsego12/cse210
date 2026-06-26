using System;

public class ChecklistGoal : BaseGoal
{
    private int _target;
    private int _completions;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int target, int bonusPoints)
        : base(name, description, points)
    {
        _target = target;
        _completions = 0;
        _bonusPoints = bonusPoints;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonusPoints, int completions)
        : base(name, description, points)
    {
        _target = target;
        _bonusPoints = bonusPoints;
        _completions = completions;

        if (_completions >= _target)
        {
            SetComplete(true);
        }
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("This checklist goal has already been completed.");
            return 0;
        }

        _completions++;

        int pointsEarned = GetPoints();

        if (_completions >= _target)
        {
            SetComplete(true);
            pointsEarned += _bonusPoints;
        }

        return pointsEarned;
    }

    public override string GetGoalDetails()
    {
        string checkbox = "[ ]";

        if (IsComplete())
        {
            checkbox = "[X]";
        }

        return $"{checkbox} {GetName()} ({GetDescription()}) -- Currently completed: {_completions}/{_target}";
    }

    public override string GetSavedData()
    {
        return $"ChecklistGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_target}|{_bonusPoints}|{_completions}";
    }
}