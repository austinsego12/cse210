public class SwimmingActivity : Activity
{
    private int _laps;

    public SwimmingActivity(string date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        // Each lap is 50m, convert to miles: meters / 1609.34
        double meters = _laps * 50.0;
        return meters / 1609.34;
    }

    public override double GetSpeed()
    {
        // mph
        double hours = GetMinutes() / 60.0;
        return GetDistance() / hours;
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance();
    }
}
