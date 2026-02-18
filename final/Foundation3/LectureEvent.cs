public class LectureEvent : Event
{
    private string _speakerName;
    private int _capacity;

    public LectureEvent(string title, string description, string date, string time, Address address, string speakerName, int capacity)
        : base(title, description, date, time, address)
    {
        _speakerName = speakerName;
        _capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()}\nType: Lecture\nSpeaker: {_speakerName}\nCapacity: {_capacity}";
    }

    public override string GetShortDetails()
    {
        return $"Lecture: {GetTitle()} on {GetDate()}";
    }
}
