# Redirection

*This lecture is optional and covers some more advanced topics in a practical setting. The contents of this lecture will not be required in any future lectures or projects.*

In this lecture, we will learn the basics of redirecting inputs and outputs for console applications in C#. We discuss some of the practical applications of performing redirection along with some simple implementations.

## Setup

In order to run the code in this lecture, the following command must be entered at the command line from the root of the repository. (Note that for all specified commands, the `$` symbol denotes the prompt and should not be typed out.)

```bash
$ cd lectures/1-variables/12-redirection/
```

This simply changes the directory that we refer to with other commands.

## Inputs and Outputs

A console application is associated with a **standard input** and a **standard output**. Both of these are specified outside of the application and are the links between input devices or files and output devices or files. In all of the code that we have written up to this point, the standard input has been the keyboard controlling the terminal and the standard output has been the screen buffer of the terminal.

## Redirection

Many console applications support inputs and outputs to and from files, network downloads and uploads, or values specified at the terminal. This is called redirection. We use redirection in creating projects for this tutorial series to test whether certain inputs to console applications produce the correct outputs.

## Readers and Writers

We can perform redirection in C# console applications using instances of `TextReader` or `TextWriter` values. A `TextReader` represents an input because we *read* from an input whereas a `TextWriter` represents an output because we *write* to an output.

The following code snippet demonstrates how to redirect the standard input to a `TextReader` instance:
```csharp
TextReader reader;
Console.SetIn(reader);
```

The following code snippet demonstrates how to redirect the standard output to a `TextWriter` instance:
```csharp
TextWriter writer;
Console.SetOut(writer);
```

Although a `TextReader` or `TextWriter` defines what can be used as inputs and outputs to a console application respectively, we cannot initialize a `TextReader` nor `TextWriter`. Instead, we create more specific types that are subclasses. In particular, we will discuss how to use `StringReader` and `StringWriter` as types of `TextReader` and `TextWriter` respectively.

Just like how an `int` can be equivalently represented as a `long`, a `StringReader` can be equivalently represented as a `TextReader` and a `StringWriter` can be equivalently represented as a `TextWriter`. Thus, we can perform the following:
```csharp
StringReader strReader;
TextReader txtReader = strReader;
```
and
```csharp
StringWriter strWriter;
TextWriter txtWriter = strWriter;
```

A `StringReader` is created using a `string` value with the same `new` syntax that we use when initializing `Random`. The `string` value acts as the sequence of characters that a user inputs using the keyboard. For example, by performing the following redirection, we simulate the user entering the string `"32"` without the user actually entering anything:
```csharp
// Redirect to the string "32".
StringReader reader = new StringReader("32\n");
Console.SetIn(reader);

// Read in and parse an integer.
string input = Console.ReadLine();
bool parseSuccess = int.TryParse(input, out int number);

// Output doubled number.
// Outputs "2 x 32 = 64".
Console.WriteLine($"2 x {number} = {2 * number}");
```
Notice that we use a newline character `'\n'` at the end of our `StringReader` `string`. This simulates the user pressing the Enter key and is necessary for `Console.ReadLine` to not hang indefinitely. 

In contrast, a `StringWriter` is created with no parameters. When it is used as a redirection output, it accumulates a `string` value that represents the total output. We can access it by using the `ToString` method. The following code shows how we might use this to gather the output of a program:
```csharp
// Redirect to a new string writer.
StringWriter writer = new StringWriter();
Console.SetOut(writer);

// Perform some outputs.
Console.Write("This ");
Console.WriteLine("is");
Console.WriteLine("some text!");

// Capture the output that was made.
// Stores "This is\nsome text!\n".
string outputs = writer.ToString();
```
Notice that the newline character `'\n'` is placed into the output `string` whenver `Console.WriteLine` is used.

## Exercises

A program demonstrating the use of the user input is provided as `Program.cs`. Read through this example program and run it using the `dotnet run` command.

Modify the provided code to implement the following exercises. Then, execute the code using the `dotnet run` command and check your work.

1. Define two constant inputs to the program. These should be `string` values that represent the text that the user would input for each number. Then, concatenate these values together using a newline operator. Create a `StringReader` from this concatenated `string` and redirect the input of the console application to use this reader.
   
   *The result should be that the user will not need to enter anything into the terminal. Instead, the values you have defined will be used.*

2. Store the original output writer using the following code:
    ```csharp
    var standardOutput = Console.Out;
    ```
    Then, redirect the output of the console application to a new `StringWriter` that you have defined. After the main bulk of the program has executed, switch the output back to `standardOutput` and output what was redirected but in all uppercase letters using `String.ToUpper(stringValue)`.

    *The result should be that the program functions as it did in the previous exercise except that all of the output is now written in capital letters.*

### Links
[Previous](../11-random/) |
[Home](../../../readme.md)

[Project 1](../../../projects/1-rock-paper-scissors/) |
[Project 2](../../../projects/2-octave-calculator/)

### References
- Readers and Writers
  - [`TextReader`](https://docs.microsoft.com/en-us/dotnet/api/system.io.textreader)
  - [`TextWriter`](https://docs.microsoft.com/en-us/dotnet/api/system.io.textwriter)
  - [`StringReader`](https://docs.microsoft.com/en-us/dotnet/api/system.io.stringreader)
  - [`StringWriter`](https://docs.microsoft.com/en-us/dotnet/api/system.io.stringwriter)
- Console Methods
  - [`Console.SetIn`](https://docs.microsoft.com/en-us/dotnet/api/system.console.setin)
  - [`Console.SetOut`](https://docs.microsoft.com/en-us/dotnet/api/system.console.setout)
  - [`Console.In`](https://docs.microsoft.com/en-us/dotnet/api/system.console.in)
  - [`Console.Out`](https://docs.microsoft.com/en-us/dotnet/api/system.console.out)