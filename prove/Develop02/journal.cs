using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    private List<Entry> entries;

    public Journal()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(string prompt, string response, string date)
    {
        entries.Add(new Entry(prompt, response, date));
    }

    public void Display()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                if (parts.Length == 3)
                {
                    entries.Add(new Entry(parts[0], parts[1], parts[2]));
                }
            }
        }
    }
}

class Entry
{
    public string Prompt { get; }
    public string Response { get; }
    public string Date { get; }

    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }
}