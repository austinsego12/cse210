using System;

public class Entry
{
    public string _date = "";
    public string _promptText = "";
    public string _entryText = "";

    // This separator is unlikely to appear in normal writing
    private const string Separator = "~|~";

    public Entry() { }

    public Entry(string date, string promptText, string entryText)
    {
        _date = date ?? "";
        _promptText = promptText ?? "";
        _entryText = entryText ?? "";
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        Console.WriteLine();
    }

    public string ToFileLine()
    {
        // Protect the separator from breaking the file format
        string safeDate = (_date ?? "").Replace(Separator, " ");
        string safePrompt = (_promptText ?? "").Replace(Separator, " ");
        string safeText = (_entryText ?? "").Replace(Separator, " ");

        return $"{safeDate}{Separator}{safePrompt}{Separator}{safeText}";
    }

    public static Entry FromFileLine(string line)
    {
        string[] parts = line.Split(Separator);

        if (parts.Length < 3)
        {
            // If the line is malformed, still load something instead of crashing
            return new Entry("", "Could not load prompt", line);
        }

        return new Entry(parts[0], parts[1], parts[2]);
    }
}
