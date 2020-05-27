# Variables

In this lecture, we will learn the basic types in C# and how to define variables using those types. We discuss how the basis types are defined and their basic properties.

## Setup

In order to run the code in this lecture, the following command must be entered at the command line from the root of the repository. (Note that for all specified commands, the `$` symbol denotes the prompt and should not be typed out.)

```bash
$ cd lectures/1-variables/3-variables/
```

This simply changes the directory that we refer to with other commands.

## Types

All values that are used in the C# programming language have a type. The type of a value defines what operations can be performed on the value and how it is stored in memory. Different types take up different amounts of space and are used for different purposes. Here, we discuss a few basic types.

We will only cover a small subset of the types provided in C# in this lecture. These are the most commonly used types. If we require other types in later lectures, we will introduce them there.

### Integral
Integral types define numerical values for the counting numbers. That is, integral types can store values such as 1, 2, 3 or -1, -2, -3 or 0. These types of values are used best for counting or working with collections of distinct objects. We will discuss two different sizes of integral types:

- `int` - a 32-bit integer. Can store values between (and including) -2,147,483,648 and +2,147,483,647. This type is most commonly used for integral values because it is not common for a count to exceed the type limits.
- `long` - a 64-bit integer. Can store values between (and including) -9,223,372,036,854,775,808 and +9,223,372,036,854,775,807. This type is not often used but is useful for representing unique IDs for objects, memory addresses, or times.
### Floating-Point
Floating-point types define numerical values for computation or approximations of real numbers. That is, floating-point types can store values such as 1.0, 1.5, -3.14, or 0.0001. These types of values are used best for calculations and scientific values. We will discuss all three types of floating-point types.

- `float` - a 32-bit floating-point number. Can store values as small as (positive or negative) 1.5E-45 and as large as (positive or negative) 3.4E+38. Uses 23 bits of precision. This is the least precise floating-point value with a decent range. It is typically acceptable to use this type for values used in games or visualizations.
- `double` - a 64-bit floating-point number. Can store values as small as (positive or negative) 5.0E-324 and as large as (positive or negative) 1.7E+308. Uses 52 bits of precision. This is a moderately precise floating-point value with an extreme range. This type is most commonly used for scientific or data-oriented applications.
- `decimal` - a 128-bit floating-point number. Can store values as small as (positive or negative) 1.0E-28 and as large as (positive or negative) 7.9E+28. Uses 96 bits of precision. This is a high precision floating-point value with a small range. Internally, numbers of this form are stored as integers with some decimal exponent. This type is most commonly used for accuracy-sensitive data such as for monetary purposes. However, the high precision that this type allows also requires more memory and computation time so it should be used sparingly.
### Boolean
A boolean type can represent one of the values `true` or `false`. This type is useful for storing whether a condition is met or not or as a flag. We will discuss boolean values more in the lectures on control statements.

- `bool`- a 8-bit integer that can take on two values: 1 and 0 representing `true` and `false` respectively. Notice that the value of a boolean could be expressed using a single bit but it uses 8 bits because memory addressing occurs at the byte level.
### Character
A character type can represent any letter or symbol from any language. These types are most useful for processes such as parsing or reading from a file. We will cover most of these purposes in later lectures. 

- `char` - a 16-bit character that can take on any unicode value using UTF-16 encoding. Examples of characters that can be represented are any upper- or lower-case letters in the English alphabet, punctuation marks, spaces, greek letters, symbols, etc. This type is usually used when using specific parts of a string type.
### String
A string is a finite sequence of characters. Typically, strings are used to represent text or documents. They are likely the most commonly used data type especially for applications that have lots of interaction with the user.

- `string` - a sequence of characters. The maximum size of a string is 1,073,741,824 or 2^30 characters. Strings have so many uses that we will cover them individually in their own section of lectures.
## Variables

A variable is a named value that can be modified and referred to in multiple locations in a program. A variable is stored in memory and any reference to a variable actually refers to the value at the corresponding location in memory.

In general, a variable is defined in the following way:

```csharp
type name = value;
```
That is,
1. We start by describing what the type of variable we want to create. So, `type` could be replaced by `int` or `bool` for example. 
2. Then, we give the variable a *descriptive* `name`. This name can be almost anything with a few exceptions that we will discuss later. Ultimately, it should describe what the variable represents.
3. Finally, we set the variable equal to some `value` of our choice. This can be a predefined variable or even the value of another variable.

Some examples of creating some variables are given in the following code snippet.

```csharp
int myFavoriteNumber = 8;
string welcomeMessage = "Hello, user!";
bool isRaining = true;
```

If we do not want to assign a value to the variables when we create them, we can leave off the value assigment part. The following snippet demonstrates this.

```csharp
int myLeastFavoriteNumber;
bool isCloudy;
```

Since these are variables, they can be changed throughout the program. For instance, my favorite number may now be 9 or it might have stopped raining. The following code snippet demonstrates modifying an existing variable.

```csharp
myFavoriteNumber = 9;
isRaining = false;
isCloudy = true;
```

Notice that we no longer need to specify the type of variable because we have already defined what types we want our variables to have.

Finally, we can use the name of our variable in place of values wherever we could previously specify a value. For instance, instead of using

```csharp
Console.WriteLine("Hello, user!");
Console.WriteLine("Your favorite number is:");
Console.WriteLine(9);
```

we can now use

```csharp
Console.WriteLine(welcomeMessage);
Console.WriteLine("Your favorite number is:");
Console.WriteLine(myFavoriteNumber);
```

and the program we function exactly the same. The benefit is that we could change the value of these variables easily without changing any of the code that uses the variables.

## Exercises

A program demonstrating the use of variables is provided as `Program.cs`. Read through this example program and run it using the `dotnet run` command.

Perform the following modifications to the provided code. Then, execute the code using the `dotnet run` command and check your work.

1. Create a boolean variable to represent whether it is the user's birthday (you can assign a fake value to this). Then, output text that says `"It is your birthday today: "` followed by the value of the boolean variable.
2. Replace all instances of `"Hello, "` with a new `string` type variable called `introduction`. Then, change the value specified as `introduction` to be `"Hi, "` instead of `"Hello, "`.
3. Use the following lines of code to get the current hour and minute. Then notify the user of what time it is in the format "`hour` h `minute`". For instance, "It is currently: 9 h 13" would be a valid notification.
    ```csharp
    int hour = DateTime.Now.Hour;
    int minute = DateTime.Now.Minute;
    ```

### Links
[Previous](../1-hello-world/) |
[Home](../../../readme.md) |
[Next](../3-variables/)

### References
- [Types](https://docs.microsoft.com/en-us/dotnet/csharp/tour-of-csharp/types-and-variables)
  - [`Int32 (int)`](https://docs.microsoft.com/en-us/dotnet/api/system.int32)
  - [`Int64 (long)`](https://docs.microsoft.com/en-us/dotnet/api/system.int64)
  - [`Single (float)`](https://docs.microsoft.com/en-us/dotnet/api/system.single)
  - [`Double (double)`](https://docs.microsoft.com/en-us/dotnet/api/system.double)
  - [`Decimal (decimal)`](https://docs.microsoft.com/en-us/dotnet/api/system.decimal)
  - [`Boolean (bool)`](https://docs.microsoft.com/en-us/dotnet/api/system.boolean)
  - [`Char (char)`](https://docs.microsoft.com/en-us/dotnet/api/system.char)
  - [`String (string)`](https://docs.microsoft.com/en-us/dotnet/api/system.string)
- [`DateTime`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)
  - [`DateTime.Now`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.now)
  - [`DateTime.Hour`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.hour)
  - [`DateTime.Minutes`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.minute)