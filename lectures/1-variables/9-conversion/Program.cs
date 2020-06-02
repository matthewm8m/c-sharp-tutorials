using System;

class Program
{
    static void Main(string[] args)
    {
        // Welcome user!
        Console.WriteLine("Welcome to the simple calculator!");

        // Read in the numeric operands.
        Console.Write("Enter operand 1: ");
        string inputOperand1 = Console.ReadLine();
        Console.Write("Enter operand 2: ");
        string inputOperand2 = Console.ReadLine();

        // Read in an operator symbol.
        Console.Write("Enter an operator symbol (+, -, *, /): ");
        char operatorSymbol = Console.ReadKey(true).KeyChar;
        Console.WriteLine(operatorSymbol);

        /*
            We need to check whether each stage of parsing the inputs is
            successful or not. We can do this by ANDing (&&) each result of
            parsing together. In the end, the parse success will be true only if
            all stages succeeded.
        */

        // Check whether the operator symbol is a valid one.
        bool parseSuccess =
            (operatorSymbol == '+') ||
            (operatorSymbol == '-') ||
            (operatorSymbol == '*') ||
            (operatorSymbol == '/');

        // Try to convert each operand input to a numeric type.
        // Keep track of whether the parsing was successful.
        parseSuccess = double.TryParse(inputOperand1, out double operand1)
            && parseSuccess;
        parseSuccess = double.TryParse(inputOperand2, out double operand2)
            && parseSuccess;

        /*
            We can use the conditional operator to compute only the result
            corresponding to the input operator symbol. The result is passed
            through each statement that does not match the operator symbol. We
            will see laster that the switch statement does a better job of this.
        */

        // Based on the operator symbol, compute some result.
        double result = 0;
        result = operatorSymbol == '+' ? operand1 + operand2 : result;
        result = operatorSymbol == '-' ? operand1 - operand2 : result;
        result = operatorSymbol == '*' ? operand1 * operand2 : result;
        result = operatorSymbol == '/' ? operand1 / operand2 : result;

        // Output the results of the calculation.
        // If there is a problem parsing, display "Parse Error" instead.
        Console.Write(inputOperand1);
        Console.Write(" ");
        Console.Write(operatorSymbol);
        Console.Write(" ");
        Console.Write(inputOperand2);
        Console.Write(" = ");
        Console.WriteLine(parseSuccess ? result.ToString() : "Parse Error");
    }
}