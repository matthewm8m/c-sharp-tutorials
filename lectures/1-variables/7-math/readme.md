# Math

In this lecture, we will learn about how to perform more complex mathematical operations on numeric values in C#. We will introduce a few of the mathematical functions that are built in to C#.

## Setup

In order to run the code in this lecture, the following command must be entered at the command line from the root of the repository. (Note that for all specified commands, the `$` symbol denotes the prompt and should not be typed out.)

```bash
$ cd lectures/1-variables/7-math/
```

This simply changes the directory that we refer to with other commands.

## Math

In the .NET library, there is a `Math` object, much similar to the `Console` object, that allows us to perform complex mathematical operations and access some nice utilities. We access these functions using a statement such as:

```csharp
double angle = Math.Atan2(0.75, 0.25);
```

When using `Math` or `Console`, the name after the dot `.` is called a **member of** whatever came before the dot `.`. In this case, `Atan2` is a function that takes in two values that is a member of `Math`.

### Constants

The two most commonly used mathematical constants, π and e, are provided in the `Math` object via two constant doubles.

- `Math.PI` (π = 3.1415926535897931)
- `Math.E` (e = 2.7182818284590451)

You can use these constants anywhere you can use a constant that you have defined. For instance,

```csharp
double areaOfCircle = Math.PI * (radius * radius);
```

calculates the area of a circle with radius `radius`.

*Recall that these constants cannot be modified at any point in the program.* 

### Functions

`Math` also provides a variety of mathematical functions that are well suited to conquer most ordinary computations. You should already know what most of these functions do in mathematics. Review them if you do not as they are commonly used in programming.

In this section, we will discuss a few of them. However, by no means is this list of `Math` functions exhaustive. Check the documentation if there is something not covered here.

- `Math.Abs` (Absolute Value Function):

    This function simply returns the positively signed version of any value. For instance,
    ```csharp
    int positiveValue = Math.Abs(-5);
    ```
    where `positiveValue` ends up with the value 5.
    
    This is commonly used for finding distances or differences (since distances are usually not negative).

- `Math.Min` (Minimum Value Function) and `Math.Max` (Maximum Value Function):

    The functions return the minimum or maximum of two input values respectively. For instance,
    ```csharp
    int minimumValue = Math.Min(2, 7);
    int maximumValue = Math.Max(2, 7);
    ```
    where `minimumValue` ends up with the value 2 and `maximumValue` ends up with the value 7.

    These functions are most commonly used for sorting or for optimization in order to find the next or optimal element of a collection. We will discuss finding the minimum or maximum of many values in a future lecture.

- `Math.Clamp` (Clamping Function):

    The clamping function takes three input values. The first is a value we wish to clamp, the second is the minimum value in the range, and the third is the maximum value in the range. The result is the value restricted to the specified range. For instance, 
    ```csharp
    int valueA = Math.Clamp(2, 1, 3);
    int valueB = Math.Clamp(0, 1, 3);
    int valueC = Math.Clamp(4, 1, 3);
    ```
    where `valueA` gets 2, `valueB` gets 1, and `valueC` gets 3. This is because 2 is in the range 1 to 3, 0 is less than 1, and 4 is greater than 3 respectively.

    This function is most commonly used to ensure that a value remains within a certain range. Consider that a player's health in a game must be greater than or equal to 0 and less than or equal to the maximum health value.

- `Math.Pow` (Power Function):

    This function is used to raise a base to a certain exponent. For instance, in the following code snippet, `value` is assigned the value -1 because (-1)^5 = -1.
    ```csharp
    var value = Math.Power(-1, 5);
    ```

    In addition to the general case with an arbitrary exponent, there are `Math` functions with specific powers that are commonly used. For instance, there are the root functions `Math.Sqrt` and `Math.Cbrt`.

    Therefore, the following pairs of statements are equivalent.
    ```csharp
    var value = Math.Power(base, 1/2d);
    var value = Math.Sqrt(base);
    ```
    and
    ```csharp
    var value = Math.Power(base, 1/3d);
    var value = Math.Cbrt(base);
    ```

    A shortcut for raising the constant `Math.E` to a power is given by the `Math.Exp` function. The following two statements are equivalent.
    ```csharp
    var value = Math.Power(Math.E, exponent);
    var value = Math.Exp(exponent);
    ```

    In addition to simplifying lines of code, the shortcuts `Math.Sqrt`, `Math.Cbrt`, and `Math.Exp` also improve the readability of your code. That is, it is more clear what the code is doing when using the exact names of functions.

- `Math.Sin`, `Math.Cos`, and `Math.Tan` (Trigonometric Functions):
  
    These functions are the standard trigonometric functions discussed in arithmetic. Each of them takes an angle value (in radians) and returns a trigonometric ratio. For instance,
    ```csharp
    double valueA = Math.Sin(Math.PI / 2.0);
    double valueB = Math.Cos(Math.PI);
    ```
    where `valueA` gets the value 1 and `valueB` gets the value -1.

    There are also inverse trigonometric functions `Math.Asin`, `Math.Acos`, and `Math.Atan` which take the trigonometric ratios from `Math.Sin`, `Math.Cos`, and `Math.Tan` respectively and return the corresponding angle. For example,
    ```csharp
    double valueC = Math.Atan(valueA / valueB);
    ```
    where `valueC` gets the value π/4.

    As an aside, `Math.Tan` always returns an angle from -π/2 to +π/2. Therefore, the second and third quadrants are not covered by this function. In order to, for example, get the angle from the origin to a point (`x`, `y`), we would instead use `Math.Atan2(y, x)`.

    The trigonometric functions are widely used across geometry, physics, and graphics.

- `Math.Log`, `Math.Log2`, `Math.Log10` (Logarithmic Functions):

    The `Math.Log` can either take two values or one value. The first is the value to take the logarithm of. The second is the base to take the logarithm with respect to. For instance,
    ```csharp
    double output = Math.Log(27d, 3d);
    ```
    where `output` gets the value 3 because 3^3 = 27.

    These functions are the standard logarithm functions with differing bases when using only one value. `Math.Log` has base e (natural logarithm), `Math.Log2` has base 2, and `Math.Log10` has base 10. Thus, the following pairs of statements are equivalent.
    ```csharp
    double value = Math.Log(input, Math.E);
    double value = Math.Log(input);
    ```
    and
    ```csharp
    double value = Math.Log(input, 2d);
    double value = Math.Log2(input);
    ```
    and
    ```csharp
    double value = Math.Log(input, 10d);
    double value = Math.Log10(input);
    ```

    The logarithm base e is mostly used in mathematics, the logarithm base 2 is often used in algorithm design, and the logarithm base 10 is usually used in physical sciences.

For all of the listed `Math` functions, the type of the input is the same as the type of the output. For example, in the following code snippet, both `input` and `output` are of type `float`.

```csharp
var input = 4.0f;
var output = Math.Sqrt(input);
```

Type promotion also applies here. For instance, if we pass an `int` and a `decimal` into a `Math` function, then, the result is a `decimal`. This is the case in the following code snippet where `output` is of type `decimal`.

```csharp
var input1 = 10;
var input2 = 35.45m;
var output = Math.Min(input1, input2);
```

## Exercises

A blank program file is provided as `Program.cs`. Write each of the following exercises in this program file. Then, execute the code using the `dotnet run` command and check your work.

1. One of the trigonometric identities between the sine, cosine, and tangent of angles is that:
    ```
    tan(a) = sin(a) / cos(a)
    ```
    Verify that this is true using a program. Let `angle` be the input angle represented by `a` in the equation. Then, find `tangent1` using `Math.Tan` and `tangent2` using `Math.Sin` and `Math.Cos`. Then, output the absolute difference (using `Math.Abs`) between `tangent1` and `tangent2`.

2. Suppose that there is an amount of money in a bank account at some initial time. The bank has some interest rate. We want to find the amount of money in the account after a number of time periods have passed. The final amount is given by the equation
    ```
    F = I (1 + i)^t
    ```
    where `F` is the final amount, `I` is the initial amount, `i` is the interest rate (from 0.0 to 1.0), and `t` is the number of time periods. Implement a program to compute the final amount in the bank account and display it to the user.
   
   *Don't forget to use the `decimal` type when storing a monetary quantity.*
3. The factorial of a positive integer `n` is denoted by `n!` and is defined as the product of all positive integers less than or equal to `n`. Verify the first few factorial values manually:
    ```
    1! = 1
    2! = 2
    3! = 6
    4! = 24
    5! = 120
    ```
    Stirling's approximation is a good approximation to factorials using a much simpler expression. Namely, `n!` is approximately equal to:
    ```
    (2πn)^(1/2) (n/e)^n
    ```
    Implement a program that specifies a positive integer `n` and produces a double `nFactorial` that approximates `n!` using Stirling's approximation. Check how these approximate values compare to the exact values (they should be relatively close).

### Links
[Previous](../6-constants/) |
[Home](../../../readme.md) |
[Next](../8-input/)

### References
- [`Math`](https://docs.microsoft.com/en-us/dotnet/api/system.math)
  - [`Math.E`](https://docs.microsoft.com/en-us/dotnet/api/system.math.e)
  - [`Math.PI`](https://docs.microsoft.com/en-us/dotnet/api/system.math.pi)
  - [`Math.Abs`](https://docs.microsoft.com/en-us/dotnet/api/system.math.abs)
  - [`Math.Min`](https://docs.microsoft.com/en-us/dotnet/api/system.math.min)
  - [`Math.Max`](https://docs.microsoft.com/en-us/dotnet/api/system.math.max)
  - [`Math.Clamp`](https://docs.microsoft.com/en-us/dotnet/api/system.math.clamp)
  - [`Math.Pow`](https://docs.microsoft.com/en-us/dotnet/api/system.math.pow)
  - [`Math.Sqrt`](https://docs.microsoft.com/en-us/dotnet/api/system.math.sqrt)
  - [`Math.Cbrt`](https://docs.microsoft.com/en-us/dotnet/api/system.math.cbrt)
  - [`Math.Exp`](https://docs.microsoft.com/en-us/dotnet/api/system.math.exp)
  - [`Math.Sin`](https://docs.microsoft.com/en-us/dotnet/api/system.math.sin)
  - [`Math.Cos`](https://docs.microsoft.com/en-us/dotnet/api/system.math.cos)
  - [`Math.Tan`](https://docs.microsoft.com/en-us/dotnet/api/system.math.tan)
  - [`Math.Asin`](https://docs.microsoft.com/en-us/dotnet/api/system.math.asin)
  - [`Math.Acos`](https://docs.microsoft.com/en-us/dotnet/api/system.math.acos)
  - [`Math.Atan`](https://docs.microsoft.com/en-us/dotnet/api/system.math.atan)
  - [`Math.Atan2`](https://docs.microsoft.com/en-us/dotnet/api/system.math.atan2)
  - [`Math.Log`](https://docs.microsoft.com/en-us/dotnet/api/system.math.log)
  - [`Math.Log2`](https://docs.microsoft.com/en-us/dotnet/api/system.math.log2)
  - [`Math.Log10`](https://docs.microsoft.com/en-us/dotnet/api/system.math.log10)
- [Compounding Interest](https://www.investopedia.com/terms/c/compoundinterest.asp)
- [Stirling's Approximation](https://en.wikipedia.org/wiki/Stirling%27s_approximation)
