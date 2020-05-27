# Operations

In this lecture, we will learn about specifying names for unchanging values in C#. Additionally, we will learn how to represent numbers using scientific notation.

## Setup

In order to run the code in this lecture, the following command must be entered at the command line from the root of the repository. (Note that for all specified commands, the `$` symbol denotes the prompt and should not be typed out.)

```bash
$ cd lectures/1-variables/6-constants/
```

This simply changes the directory that we refer to with other commands.

## Scientific Notation

In many applications, it is useful to represent very large or very small quantities using scientific notation. In C#, we can represent the number, for instance, 3.45 x 10^67 as
```csharp
double value = 3.45e67;
```
Typically, we use scientific notation when setting the values of floating-point numbers. However, we will note in passing that scientific notation can be used to set the values of integral types but this is uncommon and induces some errors.

Another syntactic convenience that C# provides is the ability the place underscores `_` in numeric literals in order to represent values with comma dividers such as the world population (which as of writing is 7,787,347,447).

```csharp
long worldPopulation = 7_787_347_447;
```

## Constants

Often in programming, we perform calculations using specific quantities such as the gravitational constant or electrostatic constant like in the following example:

```csharp
double gravitational_force = 6.673e-11 * mass1 * mass2 / (distance * distance);
double electrostatic_force = 8.99e9 * charge1 * charge2 / (distance * distance);
```

Taken out of context, the values 6.673e-11 and 8.99e9 are meaningless. To solve this problem, we name the values like variables.

```csharp
// Gravitational constant is 6.673 x 10^-11 N m^2 kg^-2.
double gravitationalConstant = 6.673e-11;
// Coulomb's constant is 8.99 x 10^9 A^-2 s^-4 m^2 kg.
double electrostaticConstant = 8.99e9;
```

However, since these are regular variables they could possibly be changed throughout the program which might unintentionally break code. Instead, we define the variable as a constant.

We prefix a variable declaration with the `const` keyword to indicate that we wish to prevent the value from changing. We also use a different convention when naming constants than when naming variables. Instead of using camel case, we use all uppercase words with underscores `_` separating words. For instance,

```csharp
// Gravitational constant is 6.673 x 10^-11 N m^2 kg^-2.
const double GRAVITATIONAL_CONSTANT = 6.673e-11;
// Coulomb's constant is 8.99 x 10^9 A^-2 s^-4 m^2 kg.
const double ELECTROSTATIC_CONSTANT = 8.99e9;

const string WELCOME_MESSAGE = "Hello, user!";
```

are valid declarations of constants.

Additionally, constants can be defined from other constants using basic operations. For instance:

```csharp
const long MY_FIRST_CONSTANT = 1L;
const long MY_SECOND_CONSTANT = 2 * MY_FIRST_CONSTANT;
```

Constants are usually not required to be used in programs. However, it may be helpful to define values as constants to prevent other users of your code from modifying values that were meant to remain constant unintentionally.

## Exercises

A program demonstrating the use of the constants and scientific notation is provided as `Program.cs`. Read through this example program and run it using the `dotnet run` command.

Perform the following modifications to the provided code. Then, execute the code using the `dotnet run` command and check your work. *Each of these exercises can replace the example code or be appended to it.*

1. Implement procedures for calculating electrostatic and gravitational force as described earlier in the lecture. Use the constants provided.
2. Implement a procedure for computing the number of moles in an ideal gas given the quantities pressure (in pascals), volume (in m^3), and temperature (in Kelvin) using the ideal gas law.

    *(Pressure) * (Volume) = (Gas Constant) * (# Moles) * (Temperature)*

    *(Gas Constant) = (Boltzmann Constant) * (Avogadro Constant)*

    *(Boltzmann Constant) = 1.380 x 10^-23 J/K*

    *(Avogadro Constant) = 6.022 x 10^23 1/mol*

### Links
[Home](../../../readme.md)

### References
- [Numeric Literals](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types)
- [Constants](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/const)
- [Gravitational Law](https://en.wikipedia.org/wiki/Newton%27s_law_of_universal_gravitation)
- [Electrostatic Law](https://en.wikipedia.org/wiki/Coulomb%27s_law)
- [Ideal Gas Law](https://en.wikipedia.org/wiki/Ideal_gas_law)