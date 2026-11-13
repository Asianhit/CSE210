using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction defaultFraction = new Fraction();
        DisplayFraction("Default constructor", defaultFraction);

        Fraction wholeNumberFraction = new Fraction(5);
        DisplayFraction("Whole-number constructor", wholeNumberFraction);

        Fraction fraction = new Fraction(3, 4);
        DisplayFraction("Top and bottom constructor", fraction);

        fraction.SetTop(6);
        fraction.SetBottom(7);
        DisplayFraction("After using setters", fraction);
    }

    private static void DisplayFraction(string label, Fraction fraction)
    {
        Console.WriteLine($"{label}: {fraction.GetFractionString()}");
        Console.WriteLine($"Decimal value: {fraction.GetDecimalValue()}");
    }
}