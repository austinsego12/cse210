using System;
using System.Collections.Generic;
using System.IO;

public class FileManager
{
    public void Save(string filename, List<Entry> entries)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine(entry.ToFileString());
            }
        }
    }

    public List<Entry> Load(string filename)
    {
        List<Entry> entries = new List<Entry>();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return entries;
        }

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            Entry entry = Entry.FromFileString(line);

            if (entry != null)
            {
                entries.Add(entry);
            }
        }

        return entries;
    }
}
