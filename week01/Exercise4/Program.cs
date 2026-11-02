using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        Console.Write("Enter a number (0 to stop): ");
        int number = int.Parse(Console.ReadLine());

        while (number != 0)
        {
            numbers.Add(number);

            Console.Write("Enter a number (0 to stop): ");
            number = int.Parse(Console.ReadLine());
        }

        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

        int sum = 0;
        int min = numbers[0];
        int max = numbers[0];

        foreach (int value in numbers)
        {
            sum += value;

            if (value < min)
            {
                min = value;
            }

            if (value > max)
            {
                max = value;
            }
        }

        double average = (double)sum / numbers.Count;

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Total numbers entered: {numbers.Count}");
        Console.WriteLine($"Average: {average}");
        Console.WriteLine($"Minimum: {min}");
        Console.WriteLine($"Maximum: {max}");
    }
}
