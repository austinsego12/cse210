public class Event
{
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;

    public Event(
        string title,
        string description,
        string date,
        string time,
        Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }


    protected virtual string GetEventType()
    {
    return "Event";
    }

    public string GetStandardDetails()
    {
        return $"Title: {_title}\n" +
               $"Description: {_description}\n" +
               $"Date: {_date}\n" +
               $"Time: {_time}\n" +
               $"Address:\n{_address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
         return $"{GetEventType()}: {GetTitle()} - {GetDate()}";
    }

    protected string GetTitle()
    {
        return _title;
    }

    protected string GetDate()
    {
        return _date;
    }
}