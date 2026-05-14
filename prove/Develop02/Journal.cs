using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No journal entries have been written yet.");
        }
        else
        {
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.ToFileString());
            }
        }

        Console.WriteLine("Journal saved successfully.");
    }

    public void LoadFromFile(string fileName)
    {
        _entries.Clear();

        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            Entry entry = Entry.FromFileString(line);
            _entries.Add(entry);
        }

        Console.WriteLine("Journal loaded successfully.");
    }

    public void SearchByMood(string mood)
    {
        bool foundEntry = false;

        foreach (Entry entry in _entries)
        {
            if (entry.GetMood().ToLower() == mood.ToLower())
            {
                entry.Display();
                foundEntry = true;
            }
        }

        if (!foundEntry)
        {
            Console.WriteLine("No entries were found with that mood.");
        }
    }
}