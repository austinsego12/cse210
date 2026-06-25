using System;

public abstract class BaseGoal
{
    private string _name;
    private string _description;
    private int _points;
    private bool _isComplete;

    public BaseGoal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    public BaseGoal(string name, string description, int points, bool isComplete)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = isComplete;
    }

    public string GetName()
    {
        return _name;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public virtual bool IsComplete()
    {
        return _isComplete;
    }

    protected void SetComplete(bool isComplete)
    {
        _isComplete = isComplete;
    }

    public abstract int RecordEvent();

    public virtual string GetGoalDetails()
    {
        string checkbox = "[ ]";

        if (IsComplete())
        {
            checkbox = "[X]";
        }

        return $"{checkbox} {_name} ({_description})";
    }

    public abstract string GetSavedData();
}