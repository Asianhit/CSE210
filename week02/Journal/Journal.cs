using System;
using System.Collections.Generic;
using System.IO;
class Journal
{
    List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("There are no journal entries to display.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._promptText}|{entry._entryText}");
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            throw new FileNotFoundException("Journal File was not Found.", fileName);
        }

        _entries.Clear();

        foreach (string line in File.ReadAllLines(fileName))
        {
            string[] fields = line.Split('|', 3);

            if (fields.Length != 3)
            {
                throw new FormatException("Journal file contains an invalid entry.");
            }

            Entry entry = new Entry();
            entry._date = fields[0];
            entry._promptText = fields[1];
            entry._entryText = fields[2];

            _entries.Add(entry);
        }
    }
}
