using System;

class Program
{
    static void Main(string[] args)
    {
        /*
            We use Console.Write in this program which does not move to the next
            line after printing our text. Therefore, by following a
            Console.Write with a Console.WriteLine, we will write two pieces of
            text on the same line and move to the next line.
        */

        // Create a string variable to represent the name of the user.
        string userName = "Bob";

        // Create an integer variable to represent the number of times we greet
        // the user.
        int helloCount;

        // Welcome the user.
        Console.Write("Hello, ");
        Console.WriteLine(userName);
        helloCount = 1;

        // Welcome the user again.
        Console.Write("Hello, ");
        Console.WriteLine(userName);
        helloCount = 2;

        // Describe how many greetings we've given.
        Console.Write("I've said hello to you ");
        Console.Write(helloCount);
        Console.WriteLine(" times!");

        // Bid farewell to the user.
        Console.Write("Goodbye, ");
        Console.WriteLine(userName);
    }
}
