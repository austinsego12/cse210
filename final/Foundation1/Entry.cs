using System;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _text;

    public Entry(string date, string prompt, string text)
    {
        _date = date;
        _prompt = prompt;
        _text = text;
    }

    public string GetDate()
    {
        return _date;
    }

    public string GetPrompt()
    {
        return _prompt;
    }

    public string GetText()
    {
        return _text;
    }

    public void Display()
    {
        Console.WriteLine($"{_date} - {_prompt}");
        Console.WriteLine(_text);
        Console.WriteLine();
    }

    public string ToFileString()
    {
        // Using a delimiter that is unlikely to appear in text
        return $"{_date}||{_prompt}||{_text}";
    }

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split("||");

        if (parts.Length < 3)
        {
            return null;
        }

        return new Entry(parts[0], parts[1], parts[2]);
    }
}
