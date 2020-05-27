using System;

class Program
{
    static void Main(string[] args)
    {
        /*
            Define constants for:
            - Pi: 3.14159265
            - Planck's Constant: 6.626 x 10^-34
            - Planck's Reduced Constant: 6.626 x 10^-34 / 2 Pi
        */
        const double PI = 3.14159265;
        const double PLANCK = 6.626e-34;
        const double REDUCED_PLANCK = PLANCK / (2.0 * PI);

        // Define deviation in position.
        double deviation_position = 1e-20;

        // Determine the minimum deviation in momentum using
        // Heisenberg's Uncertainty Principle.
        double deviation_momentum = REDUCED_PLANCK / (2.0 * deviation_position);

        Console.Write("Given a particle with position measured to within ");
        Console.Write(deviation_position);
        Console.Write(
            " m, we can accurately measure the momentum of the particle to " +
            "within ");
        Console.Write(deviation_momentum);
        Console.WriteLine(" kg m/s.");
    }
}