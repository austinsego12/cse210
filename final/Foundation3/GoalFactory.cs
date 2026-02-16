using System;

public static class GoalFactory
{
    // Format:
    // SimpleGoal|name|desc|points|isComplete
    // EternalGoal|name|desc|points
    // ChecklistGoal|name|desc|points|bonus|target|count
    public static Goal FromSaveString(string line)
    {
        string[] parts = line.Split('|');
        if (parts.Length < 4) return null;

        string type = parts[0];

        if (type == "SimpleGoal")
        {
            string name = parts[1];
            string desc = parts[2];
            int points = int.Parse(parts[3]);
            bool isComplete = bool.Parse(parts[4]);
            return new SimpleGoal(name, desc, points, isComplete);
        }

        if (type == "EternalGoal")
        {
            string name = parts[1];
            string desc = parts[2];
            int points = int.Parse(parts[3]);
            return new EternalGoal(name, desc, points);
        }

        if (type == "ChecklistGoal")
        {
            string name = parts[1];
            string desc = parts[2];
            int points = int.Parse(parts[3]);
            int bonus = int.Parse(parts[4]);
            int target = int.Parse(parts[5]);
            int count = int.Parse(parts[6]);
            return new ChecklistGoal(name, desc, points, target, bonus, count);
        }

        return null;
    }
}
