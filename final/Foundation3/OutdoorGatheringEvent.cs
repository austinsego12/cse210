public class OutdoorGatheringEvent : Event
{
    private string _weather;

    public OutdoorGatheringEvent(string title, string description, string date, string time, Address address, string weather)
        : base(title, description, date, time, address)
    {
        _weather = weather;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Outdoor\nWeather: {_weather}";
    }

    public override string GetShortDetails()
    {
        return $"Outdoor: {GetTitle()} on {GetDate()}";
    }
}
