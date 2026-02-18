
public class CyclingActivity : Activity
{
    private double _speedMph;

    public CyclingActivity(string date, int minutes, double speedMph)
        : base(date, minutes)
    {
        _speedMph = speedMph;
    }

    public override double GetDistance()
    {
        // miles = mph * hours
        double hours = GetMinutes() / 60.0;
        return _speedMph * hours;
    }

    public override double GetSpeed()
    {
        return _speedMph;
    }

    public override double GetPace()
    {
        // pace = minutes per mile
        double distance = GetDistance();
        return GetMinutes() / distance;
    }
}
