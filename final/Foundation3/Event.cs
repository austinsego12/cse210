public class Event
{
    private string _title;
    private string _description;
    private string _date;
    private string _time;
    private Address _address;

    public Event(string title, string description, string date, string time, Address address)
    {
        _title = title;
        _description = description;
        _date = date;
        _time = time;
        _address = address;
    }

    public string GetStandardDetails()
    {
        return $"{_title}\n{_description}\nDate: {_date}\nTime: {_time}\nLocation:\n{_address.GetFullAddress()}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDetails()
    {
        return $"{_title} on {_date}";
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
