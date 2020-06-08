using System;

public class Program
{
    public static void Main()
    {
        // Create the random number generator.
        Random rng = new Random();

        // Generate a random integer [0, 5] and add 1 to get [1, 6].
        // This will represent a dice roll.
        int dieRoll = rng.Next(6) + 1;

        // Display the results of the dice roll.
        Console.WriteLine($"A die came up {dieRoll}.");
    }
}