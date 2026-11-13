using System;
using System.IO;

class Program
// I added another class named MoodTracker, to check how the user feel and record their feelings and
// and record it.
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();
        MoodTracker moodTracker = new MoodTracker();
        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine();
            Console.WriteLine("Journal Menu");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal");
            Console.WriteLine("4. Load the journal");
            Console.WriteLine("5. Quit");
            Console.WriteLine("6. Display mood summary");
            Console.Write("Choose an option: ");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine(prompt);
                    Console.Write("> ");
                    string response = Console.ReadLine();
                    string mood = moodTracker.GetMood();

                    Entry entry = new Entry();
                    entry._date = DateTime.Now.ToString("yyyy-MM-dd");
                    entry._promptText = prompt;
                    entry._entryText = response;
                    entry._mood = mood;
                    journal.AddEntry(entry);
                    break;

                case "2":
                    journal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter the file name to save to: ");
                    string saveFileName = Console.ReadLine();
                    journal.SaveToFile(saveFileName);
                    Console.WriteLine("Journal saved.");
                    break;

                case "4":
                    Console.Write("Enter the file name to load: ");
                    string loadFileName = Console.ReadLine();

                    try
                    {
                        journal.LoadFromFile(loadFileName);
                        Console.WriteLine("Journal loaded.");
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("That journal file was not found.");
                    }
                    break;

                case "5":
                    Console.WriteLine("Goodbye.");
                    break;

                case "6":
                    moodTracker.DisplaySummary(journal.Entries);
                    break;

                default:
                    Console.WriteLine("Please choose an option from 1 to 6.");
                    break;
            }
        }
    }
}