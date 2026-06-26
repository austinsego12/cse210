using System;

public class EternalGoal : BaseGoal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordEvent()
    {
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetGoalDetails()
    {
        return $"[ ] {GetName()} ({GetDescription()})";
    }

    public override string GetSavedData()
    {
        return $"EternalGoal|{GetName()}|{GetDescription()}|{GetPoints()}";
    }
}