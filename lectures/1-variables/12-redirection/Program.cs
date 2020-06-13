using System;

class Program
{
    static void Main(string[] args)
    {
        // Specify the tolerance at which we consider numeric values to be
        // approximately the same.
        const double TOLERANCE = 1e-2;

        // Input two numbers from the user.
        Console.WriteLine("Enter two numbers:");
        string inputNumber1 = Console.ReadLine();
        string inputNumber2 = Console.ReadLine();

        // Parse the string inputs into numbers.
        bool parseSuccess = true;
        parseSuccess = double.TryParse(inputNumber1, out double number1)
            && parseSuccess;
        parseSuccess = double.TryParse(inputNumber2, out double number2)
            && parseSuccess;

        // Compare the two numbers and create a comparison result string.
        string result = "";
        result = Math.Abs(number1 - number2) <= TOLERANCE ?
            "approximately equal to" : result;
        result = number1 - number2 > TOLERANCE ?
            "greater than" : result;
        result = number2 - number1 > TOLERANCE ?
            "less than" : result;
        result = number1 == number2 ?
            "equal to" : result;

        // Output the comparison of the two numbers.
        Console.WriteLine(parseSuccess ?
            $"{number1} is {result} {number2}." : "Invalid input.");
    }
}
