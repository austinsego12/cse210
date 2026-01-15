using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _entryText;

    private string _mood;
    private string _tags;

    private const string Separator = "~|~";

    public Entry()
    {
        _date = "";
        _promptText = "";
        _entryText = "";
        _mood = "";
        _tags = "";
    }

    public Entry(string date, string promptText, string entryText, string mood = "", string tags = "")
    {
        _date = date ?? "";
        _promptText = promptText ?? "";
        _entryText = entryText ?? "";
        _mood = mood ?? "";
        _tags = tags ?? "";
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");

        if (!string.IsNullOrWhiteSpace(_mood))
        {
            Console.WriteLine($"Mood: {_mood}");
        }

        if (!string.IsNullOrWhiteSpace(_tags))
        {
            Console.WriteLine($"Tags: {_tags}");
        }

        Console.WriteLine();
    }

    public string ToFileLine()
    {
        string safeDate = SafeField(_date);
        string safePrompt = SafeField(_promptText);
        string safeText = SafeField(_entryText);
        string safeMood = SafeField(_mood);
        string safeTags = SafeField(_tags);

        return $"{safeDate}{Separator}{safePrompt}{Separator}{safeText}{Separator}{safeMood}{Separator}{safeTags}";
    }

    public static Entry FromFileLine(string line)
    {
        if (line == null)
        {
            return new Entry();
        }

        string[] parts = line.Split(new string[] { Separator }, StringSplitOptions.None);

        if (parts.Length < 3)
        {
            return new Entry("", "Could not load prompt", line);
        }

        string date = parts[0];
        string prompt = parts[1];
        string text = parts[2];

        string mood = parts.Length > 3 ? parts[3] : "";
        string tags = parts.Length > 4 ? parts[4] : "";

        return new Entry(date, prompt, text, mood, tags);
    }

    private static string SafeField(string value)
    {
        return (value ?? "").Replace(Separator, " ");
    }
}

