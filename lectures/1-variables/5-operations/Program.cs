using System;

class Program
{
    static void Main(string[] args)
    {
        // Specify the base and height of a geometric triangle.
        double triangleBase = 1.2;
        double triangleHeight = 3.0;

        // Compute the area of the triangle.
        double triangleArea = (triangleBase * triangleHeight) / 2;

        Console.Write("The area of a triangle with a base of ");
        Console.Write(triangleBase);
        Console.Write(" and a height of ");
        Console.Write(triangleHeight);
        Console.Write(" is ");
        Console.WriteLine(triangleArea);


        // Specify the base and height of a geometric rectangle.
        double rectangleBase = 1.2;
        double rectangleHeight = 1.5;

        // Compute the area of the rectangle.
        double rectangleArea = rectangleBase * rectangleHeight;

        Console.Write("The area of a rectangle with a base of ");
        Console.Write(rectangleBase);
        Console.Write(" and a height of ");
        Console.Write(rectangleHeight);
        Console.Write(" is ");
        Console.WriteLine(rectangleArea);

        /*
            In the following section, we concatenate strings together using the
            `+` operator. This allows us to write long strings across multiple
            lines without going past our 80 character limit on the size of each
            line.
        */

        // Is triangle bigger in area?
        Console.Write(
            "The area of the triangle is greater than the area of the " +
            "rectangle: ");
        Console.WriteLine(triangleArea > rectangleArea);

        // Is triangle smaller in area?
        Console.Write(
            "The area of the triangle is less than the area of the " +
            "rectangle: ");
        Console.WriteLine(triangleArea < rectangleArea);

        // Is triangle the same in area?
        Console.Write(
            "The area of the triangle is equal to the area of the " +
            "rectangle: ");
        Console.WriteLine(triangleArea == rectangleArea);
    }
}
