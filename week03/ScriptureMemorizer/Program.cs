using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(
            reference,
            "For God so loved the world that he gave his only begotten Son.");

        // Stretch challenge: let the player choose how many words to hide each turn.
        int wordsToHide;

        while (true)
        {
            Console.WriteLine("Choose a difficulty level");
            Console.WriteLine("1. Easy (Hide 1 word)");
            Console.WriteLine("2. Mid (Hide 2 words)");
            Console.WriteLine("3. Hard (Hide 3 words)");
            Console.WriteLine("Enter 1, 2, or 3");

            string choice = Console.ReadLine();

            if (int.TryParse(choice, out wordsToHide) && wordsToHide >= 1 && wordsToHide <= 3)
            {
                break;
            }
            Console.WriteLine("Please enter 1, 2, or 3.\n");
        }

        string response = "";

        while (response != "quit" && !scripture.IsCompletelyHidden())
        {
            if (!Console.IsOutputRedirected)
            {
                Console.Clear();
            }

            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide more words, or type 'quit' to exit.");

            response = Console.ReadLine() ?? "quit";

            if (response != "quit")
            {
                scripture.HideRandomWords(wordsToHide);
            }
        }

        if (!Console.IsOutputRedirected)
        {
            Console.Clear();
        }

        Console.WriteLine(scripture.GetDisplayText());
    }
}