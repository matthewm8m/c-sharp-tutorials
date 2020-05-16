using System;

class Program
{
    static void Main(string[] args)
    {
        // Display red holiday text.
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("This is the first holiday color!");

        // Display green holiday text.
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("This is the second holiday color!");

        /*
            Reset the console colors to their original state.

            If we do not reset colors, the terminal may use the same colors that we
            have set which may be hard to see depending on the terminal.

            Also, we should not assume that the default colors are black and white.
        */
        Console.ResetColor();

        /*
            Wait for the user to press any key before exiting.

            We use the `Console.ReadKey` method to record the keypress.
            By passing in `true`, we prevent the key from being written to the terminal.
        */
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey(true);
    }
}
