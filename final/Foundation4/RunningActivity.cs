public class RunningActivity : Activity
{
    private double _miles;

    public RunningActivity(string date, int minutes, double miles)
        : base(date, minutes)
    {
        _miles = miles;
    }

    public override double GetDistance()
    {
        return _miles;
    }

    public override double GetSpeed()
    {
        // mph = miles / hours
        double hours = GetMinutes() / 60.0;
        return _miles / hours;
    }

    public override double GetPace()
    {
        // min per mile
        return GetMinutes() / _miles;
    }
}
