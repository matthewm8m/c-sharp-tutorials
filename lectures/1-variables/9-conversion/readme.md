# Conversion

In this lecture, we will learn how to convert between different compatible types in C#. We will discuss the difference between implicit and explicit conversion and methods of performing both. Finally, we discuss the difference between type conversion and parsing and show how to convert user input into numerical values.

## Setup

In order to run the code in this lecture, the following command must be entered at the command line from the root of the repository. (Note that for all specified commands, the `$` symbol denotes the prompt and should not be typed out.)

```bash
$ cd lectures/1-variables/9-conversion/
```

This simply changes the directory that we refer to with other commands.

## Conversion

Type conversion is extremely important in programming because we rarely are presented with information in the form that we wish to work with. For example, users will typically enter text information but computers are best designed to calculate with numbers. 

### Implicit

An **implicit conversion** is a conversion from one type to another without any special syntax or conversion statements. Implicit conversions do not cause any loss of information.

Type promotion is an instance of implicit conversion. Recall that we can perform the following type promotions:
- `int` to `long`, `float`, `double`, `decimal`
- `long` to `float`, `double`, `decimal`
- `float` to `double`
This not only applies when we are operating on two different types. It also applies whenever the type expected is different than the type used and the latter can be converted to the former. For example, we can assign a `long` value from a `int` value:

```csharp
int intValue = 2;
long longValue = intValue;
```

Additionally, the `Math.Log` function expects a double but we can provide it with a `float`:

```csharp
double logResult = Math.Log(9.5f);
```

Notice that we cannot implicitly convert types in the opposite direction. For instance, an error is raised if trying to assign a `float` using a `double`:

```csharp
double doubleValue = 1d;
float floatValue = doubleValue; // Raises an error. Invalid conversion!
```

There are other types of implicit conversion that we will discuss later when they arise.

### Explicit

An **explicit conversion** is a conversion from one type to another using a special syntax or a conversion statement. Explicit conversion may result in the loss of information.

The most common type of explicit conversion is a type cast. It has the following general form:
```csharp
type valueConverted = (type)value;
```
In this case, `type` is the type that we wish to convert to and `(type)` is called the type cast operator. This form of type conversion is allowed to reverse type promotion for the basic types. For example, we can convert a `double` to an `int` this way by using the following code:
```csharp
double doubleValue = 2.67;
int intValue = (int)doubleValue;
```
After this code is executed, `intValue` stores the value `2`. This is because all digits after the decimal point are dropped upon conversion from a floating-point value to an integral value.

Explicit type conversions can also be performed in the same direction as type promotions. This can be used to clarify that a value should be treated as a different type in calculations without defining any new variables. For instance, the following code divides two `int` values and produces a `double` result without defining any intermediate variables using a type cast:
```csharp
int valueA = 3;
int valueB = 2;
double quotient = (double)valueA / valueB;
```
Notice that leaving off the type cast `(double)` in this snippet would result in `quotient` with the value of `1.0`. This is because an `int` divided by an `int` results in an `int`. After the division, the `int` is promoted to a `double`. However, with the type cast, we have a `double` divided by an `int` which produces a `double`.

## Parsing

Parsing typically refers to converting a `string` representation of a value to another type. For example, converting the `string` with value `"-14"` to the `int` with value `-14` is an instance of parsing. It is similar to type conversion in that our input is one type, a `string` type, and our output is another type. However, type conversion involves transferring a value across types whereas parsing is a transformation of one value to another.

In general, the syntax to parse basic types in C# is given by the following code snippet:
```csharp
string input = Console.ReadLine();
bool success = type.TryParse(input, out type output);
```
where `type` is one of the basic types including `bool`, `int`, `long`, `float`, `double`, and `decimal`. Notice that `input` is a string, not necessarily input by the user, and is input into a `TryParse` method associated with the type we are trying to create. The output of the parsing is `output` which has type `type`. This uses the special notation `out type` to define a new variable in the statement. For now, we will take this syntax as granted but we will discuss it further in a later lecture. Finally, whether the parse was successful or not is stored in the `success` variable of type `bool`.

A concrete example of parsing an `int` is given in the following code snippet:
```csharp
bool success = int.TryParse("26", out int numericValue);
Console.WriteLine(success);         // Outputs True
Console.WriteLine(numericValue);    // Outputs 26
```
Here is an example of parsing an ill-formatted `int`:
```csharp
bool success = int.TryParse("1.1", out int numericValue);
Console.WriteLine(success);         // Outputs False
Console.WriteLine(numericValue);    // Outputs 0
```
Here is an example of parsing a `bool`:
```csharp
bool success = bool.TryParse("False", out bool booleanValue);
Console.WriteLine(success);         // Outputs True
Console.WriteLine(booleanValue);    // Outputs False
```
Finally, here is an example of parsing a `decimal`:
```csharp
bool success = decimal.TryParse("1.55", out decimal decimalValue);
Console.WriteLine(success);         // Outputs True
Console.WriteLine(decimalValue);    // Outputs 1.55
```

## String Representation

For every type in C#, we can perform the inverse operation of parsing. That is, we can convert a value of any type back to a string using its `ToString` method. For example, the following code snippet converts a `bool` to a string.

```csharp
bool booleanValue = true;
string stringRepresentation = booleanValue.ToString();
```

It turns out that whenever we use `Console.Write` or `Console.WriteLine` with a non-`string` value, the program is actually using `ToString` to convert the value to a `string` and then displaying it normally. So, the following statements are equivalent:

```csharp
Console.WriteLine(someValue.ToString());
Console.WriteLine(someValue);
```

For the basic types, converting to a string representation produces a parseable `string`. So, if we were to parse this string representation, we would obtain the same value that we started with. For instance, we perform this with an `int` in the following snippet:

```csharp
int number = -14;
string numberString = number.ToString();
int.TryParse(numberString, out int numberParsed);
Console.WriteLine(numberParsed + 1);    // Outputs -13
```

## Exercises

A program demonstrating the use of the user input is provided as `Program.cs`. Read through this example program and run it using the `dotnet run` command.

Replace the provided code with implementations to the following exercises. Then, execute the code using the `dotnet run` command and check your work.

1. Prompt the user for two floating-point numbers. Then, calculate the the first number divided by the second number. Use type casting to determine the quotient (as an integer) and the remainder. Output this to the user. For instance,
   ```
   7.5 / 2.1 = 3 + 1.2 / 2.1
   ```
   
   *Hint: use an explicit type case from a `double` to an `int` to drop all digits after the decimal place.*

2. Verify for the `double` type the property of reparseability. Prompt the user for a number. Parse this and store it as `number1`. Then, convert it to a string and parse it again and store it as `number2`. Assert that `number1 == number2` and notify the user of the result.

### Links
[Previous](../8-input/) |
[Home](../../../readme.md) |
[Next](../10-output/)

[Project 1](../../../projects/1-rock-paper-scissors/) |
[Project 2](../../../projects/2-octave-calculator/)

### References
- [Casting](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/casting-and-type-conversions)
- Parsing
  - [`int.TryParse`](https://docs.microsoft.com/en-us/dotnet/api/system.int32.tryparse)
  - [`long.TryParse`](https://docs.microsoft.com/en-us/dotnet/api/system.int64.tryparse)
  - [`bool.TryParse`](https://docs.microsoft.com/en-us/dotnet/api/system.boolean.tryparse)
  - [`float.TryParse`](https://docs.microsoft.com/en-us/dotnet/api/system.single.tryparse)
  - [`double.TryParse`](https://docs.microsoft.com/en-us/dotnet/api/system.double.tryparse)
  - [`decimal.TryParse`](https://docs.microsoft.com/en-us/dotnet/api/system.decimal.tryparse)
  - [`out`](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/out-parameter-modifier)
- String Representation
  - [`int.ToString`](https://docs.microsoft.com/en-us/dotnet/api/system.int32.tostring)
  - [`long.ToString`](https://docs.microsoft.com/en-us/dotnet/api/system.int64.tostring)
  - [`bool.ToString`](https://docs.microsoft.com/en-us/dotnet/api/system.boolean.tostring)
  - [`float.ToString`](https://docs.microsoft.com/en-us/dotnet/api/system.single.tostring)
  - [`double.ToString`](https://docs.microsoft.com/en-us/dotnet/api/system.double.tostring)
  - [`decimal.ToString`](https://docs.microsoft.com/en-us/dotnet/api/system.decimal.tostring)
  - [`object.ToString`](https://docs.microsoft.com/en-us/dotnet/api/system.object.tostring)