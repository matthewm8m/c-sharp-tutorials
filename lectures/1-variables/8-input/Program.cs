using System;

class Program
{
    static void Main(string[] args)
    {
        // Get user's first name.
        Console.WriteLine("What is your first name?");
        string firstName = Console.ReadLine();

        /*
            Notice that we intercept the character and write it back out to the
            terminal. This is because the `Console.ReadKey` method does not
            automatically move to the next line. This will cause the next text
            to be written to be mixed in with the user input. Therefore, we use
            `Console.WriteLine` to ensure we move to the next line before the
            next line of text.
        */

        // Get user's middle initial.
        Console.WriteLine("What is your middle initial?");
        char middleInitial = Console.ReadKey(true).KeyChar;
        Console.WriteLine(middleInitial);

        // Get user's last name.
        Console.WriteLine("What is your last name?");
        string lastName = Console.ReadLine();

        // Output the user's full name.
        Console.Write("Welcome, ");
        Console.Write(firstName);
        Console.Write(" ");
        Console.Write(middleInitial);
        Console.Write(". ");
        Console.Write(lastName);
        Console.WriteLine("!");
    }
}