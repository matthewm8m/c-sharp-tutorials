using System;

class Program
{
    static void Main(string[] args)
    {
        // These are messages to display to the user of type string.
        var welcomeMessage = "Hello, user!";
        var numberMessage = "Your favorite number is ";

        // This is the user's favorite number.
        var favoriteNumber = 20;

        // Display the welcome message and user's favorite number.
        Console.WriteLine(welcomeMessage);
        Console.Write(numberMessage);
        Console.WriteLine(favoriteNumber);

        /*
            This uses a little bit of reflection which is the use of the source
            code at execution time. We use reflection to get the name of the
            type of the `favoriteNumber` variable.
        */
        // Display the type of the favorite number literal.
        Console.Write("The number is of the type ");
        Console.WriteLine(favoriteNumber.GetType().Name);
    }
}
