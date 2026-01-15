using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        if (entry != null)
        {
            _entries.Add(entry);
        }
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty.");
            return;
        }

        Console.WriteLine("Journal Entries");
        Console.WriteLine();

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.ToFileLine());
                }
            }

            Console.WriteLine($"Saved {_entries.Count} entries to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);

            // Replace current entries, per assignment requirements
            _entries = new List<Entry>();

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                Entry entry = Entry.FromFileLine(line);
                _entries.Add(entry);
            }

            Console.WriteLine($"Loaded {_entries.Count} entries from {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }
}
