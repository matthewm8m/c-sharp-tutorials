# Random

In this lecture, we will learn the basics of random number generation. We will discuss topics including seeding and random states. Then, we will look into how to implement random number generation in C#.

## Setup

In order to run the code in this lecture, the following command must be entered at the command line from the root of the repository. (Note that for all specified commands, the `$` symbol denotes the prompt and should not be typed out.)

```bash
$ cd lectures/1-variables/11-random/
```

This simply changes the directory that we refer to with other commands.

## Random Value Generation

A common procedure in computer programs is the use of random values. C# provides a simple methods of generating these random values. We will cover the appropriate syntax and methods of creating random values in a predictable way.

### Random Generator

The first topic we need to cover is how to create a random number generator. We will start with the most basic form in this section. We will use the variable name `rng` to stand for the abbreviation Random Number Generator (RNG). The following code shows how to initialize an RNG:
```csharp
Random rng = new Random();
```
This statement uses a new syntax that we have not yet discussed. Namely, we use the `new` keyword to create a new RNG object. We will refrain from discussing this more until a later lecture. For now, just remember this syntax.

### Random Values

There are two primary types of values that we are interested in generating: integral values and floating-point values. The `rng` variable we initialized supports generating values of type `int` and `double`. Since we can use casts to convert between `int` and `long` and between `float`, `double`, and `decimal` this is usually sufficient.

- `int` - To generate `int` values, we use the `Random.Next` method. The most common forms of this method we will use either take a maximum value or both a maximum and minimum value.
  - When specifying only the `maximum` value, `Random.Next` returns a value greater than or equal to `0` and less than (*but not equal to*) `maximum`. For example, to generate a value from `0` through `9` (a digit), we can use the following code:
    ```csharp
    int digit = rng.Next(10);

    // Outputs one of the integers:
    // 0, 1, 2, 3, 4, 5, 6, 7, 8, 9
    Console.WriteLine(digit);
    ```
  - When specifying both a `minimum` and `maximum` value, `Random.Next` returns a value greater than or equal to `minimum` and less than (*but not equal to*) `maximum`. For example, to generate one of the values `-1`, `0`, or `+1` (a sign of a number), we can use the following code:
    ```csharp
    int sign = rng.Next(-1, 1 + 1);

    // Outputs one of the integers:
    // -1, 0, +1
    Console.WriteLine(sign);
    ```
- `double` - To generate `double` values, we use the `Random.NextDouble` method. There is only one form of this method taking no parameters and generating a value greater than or equal to `0.0` and less than (*but not equal to*) `1.0`. Often times, we do want some value between `0.0` and `1.0`. In that case, we can use the following code to generate such a value:
  ```csharp
  double value = rng.NextDouble();

  // Outputs a value between 0.0 and 1.0.
  Console.WriteLine(value);
  ```
  However, in cases when we have some abitrary `double` values `maximum` and `minimum` that define our range, we need to scale the output of `Random.NextDouble`. A value in this generalized range can be computed using the following code:
  ```csharp
  double value = (maximum - minimum) * rng.NextDouble() + minimum;

  // Outputs a value between `minimum` and `maximum`.
  Console.WriteLine(value);
  ```

### Seeds

For most psuedo-RNGs, there is some state of the generator that determines the next number to be generated. This state changes each time that a number is generated in order to produce a new random state. Usually this state is unknown to the user. However, practically all RNGs that rely on a generator state allow us to specify an intial state. This initial state is called a **seed** and the operation of specifying a seed to an RNG is called **seeding**. The following code shows how to modify our previous RNG initialization to implement for seeding:
```csharp
int seed = anyInteger;
Random rngSeeded = new Random(seed);
```
It turns out that when we do not specify a seed as we did before, a seed is generated based on the state of the computer typically involving the current time. Thus, without specifying a seed, an RNG will produce an unpredictable sequence of values that will almost certainly differ each time the program is executed.

If the same seed is specified for multiple RNGs, then they will produce the same sequence of outputs. This is demonstrated in the following code snippet:
```csharp
int seed = anyInteger;
Random rngSeeded1 = new Random(seed);
Random rngSeeded2 = new Random(seed);

int rngNumber1 = rngSeeded1.Next(1000);
int rngNumber2 = rngSeeded2.Next(1000);

// This is always equal to `true`.
bool randomNumbersEqual = rngNumber1 == rngNumber2;
```
This is typically used to create reproducible results while still maintaining general randomness for circumstances like scientific experiments, simulations, and procedural generation.

## Exercises

An example program using random number generation to simulate a dice roll is provided as `Program.cs`. Modify the existing program to implement the following exercises. Then, execute the code using the `dotnet run` command and check your work.

1. The program currently simulates a single dice roll. Modify the program to simulate a second dice roll. Sum the two dice rolls together and output the result.
   
    *Hint: You should not reinitialize the `rng` variable.*

2. Allow the user to enter a guess for the sum of the dice rolls **before** outputting the sum. Then, award the user with some points based on how close their guess was. That is, the number of points earned is
    ```
    points = max(0, 7 - abs(guess - sum))
    ```
    so that a user can earn a maximum of 7 points and a minimum of 0 points. Output the number of points earned and the actual sum of dice after the user has guessed.
   
3. Allow the user to specify an `int` seed for the RNG. Use this seed to modify the RNG initialization using seeding. Then, verify that dice rolls are the same on successive executions of the program when the seed is the same.

### Links
[Previous](../10-output/) |
[Home](../../../readme.md) |
[Next (Optional)](../12-redirection/)

[Project 1](../../../projects/1-rock-paper-scissors/) |
[Project 2](../../../projects/2-octave-calculator/)

### References
- [`Random`](https://docs.microsoft.com/en-us/dotnet/api/system.random)
  - [`Random.Next`](https://docs.microsoft.com/en-us/dotnet/api/system.random.next)
  - [`Random.NextDouble`](https://docs.microsoft.com/en-us/dotnet/api/system.random.nextdouble)