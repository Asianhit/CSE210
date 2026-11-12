using System;
using System.Collections.Generic;

public class MoodTracker
{
    private readonly string[] _moods = { "Happy", "Calm", "Stressed", "Sad" };

    public string GetMood()
    {
        while (true)
        {
            Console.WriteLine("How are you feeling today?");
            for (int i = 0; i < _moods.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {_moods[i]}");
            }

            Console.Write("Choose a mood (Select a number in the Options): ");
            string choice = Console.ReadLine();

            if (int.TryParse(choice, out int moodNumber) &&
                moodNumber >= 1 && moodNumber <= _moods.Length)
            {
                return _moods[moodNumber - 1];
            }

            Console.WriteLine("Please enter a valid mood number.");
        }
    }

    public void DisplaySummary(IReadOnlyList<Entry> entries)
    {
        if (entries.Count == 0)
        {
            Console.WriteLine("There are no journal entries to summarize.");
            return;
        }

        Dictionary<string, int> counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        foreach (string mood in _moods)
        {
            counts[mood] = 0;
        }

        foreach (Entry entry in entries)
        {
            string mood = string.IsNullOrWhiteSpace(entry._mood) ? "Unspecified" : entry._mood;
            if (!counts.ContainsKey(mood))
            {
                counts[mood] = 0;
            }

            counts[mood]++;
        }

        Console.WriteLine("Mood summary:");
        foreach (KeyValuePair<string, int> count in counts)
        {
            Console.WriteLine($"{count.Key}: {count.Value}");
        }
    }
}
