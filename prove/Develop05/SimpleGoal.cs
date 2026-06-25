using System;

public class SimpleGoal : BaseGoal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public SimpleGoal(string name, string description, int points, bool isComplete)
        : base(name, description, points, isComplete)
    {
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("This goal has already been completed.");
            return 0;
        }

        SetComplete(true);
        return GetPoints();
    }

    public override string GetSavedData()
    {
        return $"SimpleGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{IsComplete()}";
    }
}