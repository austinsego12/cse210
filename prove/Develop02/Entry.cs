using System;
using System.Text;

public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;
    private string _mood;
    private int _rating;

    public Entry(string date, string prompt, string response, string mood, int rating)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
        _rating = rating;
    }

    public void Display()
{
    Console.WriteLine();
    Console.WriteLine("My Journal Reflection");
    Console.WriteLine($"Date: {_date}");
    Console.WriteLine($"Prompt: {_prompt}");
    Console.WriteLine($"Response: {_response}");
    Console.WriteLine($"Mood: {_mood}");
    Console.WriteLine($"Daily Growth Rating: {_rating}/10");
}

    public string GetMood()
    {
        return _mood;
    }

    public string ToFileString()
    {
        return $"{Encode(_date)}|{Encode(_prompt)}|{Encode(_response)}|{Encode(_mood)}|{_rating}";
    }

    public static Entry FromFileString(string line)
    {
        string[] parts = line.Split("|");

        string date = Decode(parts[0]);
        string prompt = Decode(parts[1]);
        string response = Decode(parts[2]);
        string mood = Decode(parts[3]);
        int rating = int.Parse(parts[4]);

        return new Entry(date, prompt, response, mood, rating);
    }

    private static string Encode(string value)
    {
        byte[] bytes = Encoding.UTF8.GetBytes(value);
        return Convert.ToBase64String(bytes);
    }

    private static string Decode(string value)
    {
        byte[] bytes = Convert.FromBase64String(value);
        return Encoding.UTF8.GetString(bytes);
    }
}