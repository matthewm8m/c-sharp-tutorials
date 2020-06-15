using System;

namespace ScaleCalculator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Get whether the scale should be major or minor.
            Console.WriteLine(
                "Would you like to calculate a major or minor scale?");
            string scaleInput = Console.ReadLine();
            bool majorScale = scaleInput.ToLower().Equals("major");
            bool parseSuccess =
                scaleInput.ToLower().Equals("major") ||
                scaleInput.ToLower().Equals("minor");

            // Get the frequency for the start of the scale from the user.
            Console.WriteLine("Enter the starting frequency (in Hz):");
            string frequencyInput = Console.ReadLine();
            parseSuccess = double.TryParse(
                frequencyInput, out double frequency
            ) && parseSuccess;

            /*
                Calculate each of the frequencies of the scale. Recall that
                the major and minor scales are formulated as the following:

                - Major -
                Whole Whole Half Whole Whole Whole Half =
                2 steps, 2 steps, 1 step, 2 steps, 2 steps, 2 steps, 1 step.

                - Minor -
                Whole Half Whole Whole Half Whole Whole =
                2 steps, 1 step, 2 steps, 2 steps, 1 step, 2 steps, 2 steps.
            */
            double frequency1 = frequency *
                Math.Pow(2d, (majorScale ? 0 : 0) / 12d);
            double frequency2 = frequency *
                Math.Pow(2d, (majorScale ? 2 : 2) / 12d);
            double frequency3 = frequency *
                Math.Pow(2d, (majorScale ? 4 : 3) / 12d);
            double frequency4 = frequency *
                Math.Pow(2d, (majorScale ? 5 : 5) / 12d);
            double frequency5 = frequency *
                Math.Pow(2d, (majorScale ? 7 : 7) / 12d);
            double frequency6 = frequency *
                Math.Pow(2d, (majorScale ? 9 : 8) / 12d);
            double frequency7 = frequency *
                Math.Pow(2d, (majorScale ? 11 : 10) / 12d);
            double frequency8 = frequency *
                Math.Pow(2d, (majorScale ? 12 : 12) / 12d);

            // Output all of the frequencies if the user entered a valid input.
            Console.Write(parseSuccess ? $"Note 1: {frequency1:F2}\n" : "");
            Console.Write(parseSuccess ? $"Note 2: {frequency2:F2}\n" : "");
            Console.Write(parseSuccess ? $"Note 3: {frequency3:F2}\n" : "");
            Console.Write(parseSuccess ? $"Note 4: {frequency4:F2}\n" : "");
            Console.Write(parseSuccess ? $"Note 5: {frequency5:F2}\n" : "");
            Console.Write(parseSuccess ? $"Note 6: {frequency6:F2}\n" : "");
            Console.Write(parseSuccess ? $"Note 7: {frequency7:F2}\n" : "");
            Console.Write(parseSuccess ? $"Note 8: {frequency8:F2}\n" : "");

            // If user entered an invalid input.
            Console.Write(parseSuccess ? "" : "Invalid input.\n");
        }
    }
}