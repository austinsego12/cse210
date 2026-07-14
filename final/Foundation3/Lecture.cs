public class Lecture : Event
{
    private string _speakerName;
    private int _capacity;

    public Lecture(
        string title,
        string description,
        string date,
        string time,
        Address address,
        string speakerName,
        int capacity)
        : base(title, description, date, time, address)
    {
        _speakerName = speakerName;
        _capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\n" +
               $"Event Type: Lecture\n" +
               $"Speaker: {_speakerName}\n" +
               $"Capacity: {_capacity}";
    }

    protected override string GetEventType()
    {
        return "Reception";
    }

}