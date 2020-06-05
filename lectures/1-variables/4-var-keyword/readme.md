# `var` Keyword

In this lecture, we will learn about a handy shortcut that C# provides to automatically assign types to variables. We will discuss some of the gotchas involved in using the shortcut and its most useful situations. We also discuss how to specify the types associated with numeric literals.

## Setup

In order to run the code in this lecture, the following command must be entered at the command line from the root of the repository. (Note that for all specified commands, the `$` symbol denotes the prompt and should not be typed out.)

```bash
$ cd lectures/1-variables/4-var-keyword/
```

This simply changes the directory that we refer to with other commands.

## `var`

The C# language allows us to use a small shortcut when assigning new variables. Instead of specifying the type of variable, we can use the handy `var` keyword. It allows for the C# compiler to assign types to variables automatically based on typing rules. For instance, instead of the following snippet of code,

```csharp
string weatherReport = "Partly Cloudy";
int population = 14000;
double voltage = 9.8;
```

we can use

```csharp
var weatherReport = "Partly Cloudy";
var population = 14000;
var voltage = 9.8;
```

So, we don't have to specify the types of the variables at all. The variables are still typed, but it is the compiler that does the work. The former case is called **explicit** typing while the latter case is called **implicit** typing. This can be particularly useful when we encounter much more complicated types that take a long time to type out or are prone to causing errors.

Sometimes it is necessary to use the `var` keyword. We will discuss these cases in later lectures when we come across them. More importantly, there are some caveats to the use of `var` that we address in the rest of this lecture.

## Literals

A **literal** is a specific value that we use in programs that does not change and is not named. For instance, in the following example, `4` is a literal that is assigned to the variable `numberOfLeaves`. 

```csharp
int numberOfLeaves = 4;
```

We could also use a statement such as the following to assign the literal `1` to the variable `particleSpin`.

```csharp
double particleSpin = 1;
```

However, we have to be careful with this because the following statement is not equivalent to the previous statement.

```csharp
var particleSpin = 1;
```

Imagine reading this line as a computer. To a human, it may be clear to us that the value of our variable should be a floating-point number. However, to the computer, `1` could equally be interpretted as an integral number. In fact, as a rule, C# assigns the simplest and most common possible type to literals. So, in this instance, `particleSpin` would be assigned type `int`. There are ways to provide the compiler with hints as to the type of a literal.

### Integral

For our current purposes, we have the `int` and `long` integral types. In order to designate an `int` literal, we do as we did in the example.

```csharp
var intA = 1;
var intB = 12345;
var intC = -901;
```

All of these variables are assigned the `int` type by the compiler. To represent the `long` type, we need to add an `L` suffix to the end of our literals.

```csharp
var longA = 1L;
var longB = 100000000L;
var longC = -987654321L;
```

All of these variables are assigned the `long` type because they are followed by the letter `L`. Additionally, if a value is too large to fit into an `int` type, then, the `long` type (or possibly `uint`, discussed later, depending on the sign of the literal) is used. For instance, the following variable is a `long` type variable.

```csharp
var longD = 6000000000;
```

### Floating-Point

Without any special suffixes added to our literals, numeric values without a decimal point `.` are assigned to integral types and numeric values with a decimal point `.` are assigned to floating-point types. For instance, in the following code snippet, `withoutPoint` is an `int` and `withPoint` is a `double`.

```csharp
var withoutPoint = 20;
var withPoint = 20.0;
```

In order to override this behavior, we can uses literal suffixes again. To represent a `float` type literal, we use the `f` suffix. For instance:

```csharp
var floatA = 20f;
var floatB = 20.0f;
```

To represent a `double` type literal, we use the `d` suffix. For instance:

```csharp
var doubleA = 30d;
var doubleB = 30.0d;
```

Finally, to represent a `decimal` type literal, we use the `m` suffix (`m` is used for the decimal type because we typically use it for representing **m**oney). For instance:

```csharp
var decimalA = 40m;
var decimalB = 40.0m;
```

### Characters and Strings

In order to specify a literal that is a `char` type, we need to surround our single character with single quotes `''`.

```csharp
var charA = 'A';
var charB = ' ';
```

It is important that there is only a single character inside the quotes. Otherwise, the program will not compile. To represent a `string` type, we use double quotes `""`.

```csharp
var stringA = "text";
var stringB = "";
```

Notice that the literal `""` represents an empty string or a string with no characters.

In passing, we will note that the literal suffixes are not case sensitive. That is, `12L` and `12l` represent the same literal and `20f` and `20F` represent the same literal. However, it is common practice to represent integer literals with an uppercase letter (especially `L` since `l` looks like `1`) and floating-point literals with a lowercase letter. 

We can use these literals anywhere within the code and not just in conjunction with the `var` keyword. We will discuss more of its uses in future lectures.

## Exercises

A program demonstrating the use of the `var` keyword is provided as `Program.cs`. Read through this example program and run it using the `dotnet run` command.

Perform the following modifications to the provided code. Then, execute the code using the `dotnet run` command and check your work.

1. Use the `var` keyword to store a `ConsoleColor` variable using the following statement:
    ```csharp
        var textColor = ConsoleColor.Blue;
    ```
    Then, use the `textColor` variable to set the `Console.ForegroundColor` before the rest of the code executes. Remember to use the `Console.Reset` statement to reset the terminal colors.
2. Try changing the literal assigned to `favoriteNumber` to be each of the types `long`, `float`, and `decimal`. See how this changes the output number type.
3. Try modifying the `favoriteNumber` variable type after its definition. For instance:
    ```csharp
    var favoriteNumber = 20;
    favoriteNumber = 20d;
    ```
    What happens? We will cover type conversion shortly.

### Links
[Previous](../3-variables/) |
[Home](../../../readme.md) |
[Next](../5-operations/)

[Project 1](../../../projects/1-rock-paper-scissors/) |
[Project 2](../../../projects/2-octave-calculator/)

### References
- [`var`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/var)
- [Integral Types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types)
- [Floating-Point Types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types)
- [String Types](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/strings/)