# Comments

In this lecture, we will learn how to use C# comments for code documentation. We will discuss both single-line and multi-line comments and their common uses.

## Setup

In order to run the code in this lecture, the following command must be entered at the command line from the root of the repository. (Note that for all specified commands, the `$` symbol denotes the prompt and should not be typed out.)

```bash
$ cd lectures/1-variables/2-comments/
```

This simply changes the directory that we refer to with other commands.

## Comments

Comments are a feature of the C# programming language that allows programmers to add human-readable text that is ignored by the computer. Comments are typically used as a method of documenting code.

Comments should be used liberally to explain complex parts of code. As a rule of thumb, any set of instructions that does more than simply input, output, or change a variable should probably have a comment documenting it. This is to help others, or possibly yourself, figure out what certain code does in the future. For larger, long-term projects this is especially important because it's unlikely that you will remember every single line of code you wrote 3 months ago.

### Single-Line Comments

Typically, a short comment is placed directly before some code to describe it. We can use single-line comments for this purpose. The following **snippet**, a short segment of code or syntax, demonstrates a single-line comment.

```csharp
// This is a single-line comment!
```

The two backslashes `//` indicate the start of a comment. Any text after the `//` and on the same line is ignored and not interpreted as code. So, running the following code

```csharp
// Console.WriteLine("This line is not executed!");
Console.WriteLine("This line is executed!");
```

produces the output

```
This line is executed!
```

### Multi-Line Comments

Sometimes, a section of code requires more than a short explanation. In this case, it is better to use a multi-line comment. Typically, it is common practice to ensure that all lines of code in a program are at most, 80 characters long. If a single-line comment surpasses this limit, consider using a multi-line comment. The following snippet demonstrates a multi-line comment.

```csharp
/*
    This comment
    can span
    multiple lines.
*/
```
The backslash star `/*` starts the multi-line comment and the star backslash `*/` ends the multi-line comment. Anything between these two tokens is ignored and not interpreted as code. So, running the following code

```csharp
/*
    Console.WriteLine("This line is not executed!");
    Console.WriteLine("Neither is this one!");
*/
Console.WriteLine("This line is executed!");
```

produces the output

```
This line is executed!
```

## Exercises

A program demonstrating the use of comments is provided as `Program.cs`. Read through this example program and run it using the `dotnet run` command.

Perform the following modifications to the provided code. Then, execute the code using the `dotnet run` command and check your work.

1. Add a line of code to introduce the holiday. For example, display "Happy Halloween!" or "Merry Christmas!". Then, add a single-line comment to describe what that line is doing.
2. Use the following line of code at the beginning of the program to change the title of the terminal. Write a corresponding multi-line comment that explains what it does.
    ```csharp
    Console.Title = "Holiday Application";
    ```

### Links
[Previous](../2-comments/) |
[Home](../../../readme.md) |
[Next](../4-var-keyword/)

[Project 1](../../../projects/1-rock-paper-scissors/) |
[Project 2](../../../projects/2-octave-calculator/)

### References
- [`Console.ReadKey`](https://docs.microsoft.com/en-us/dotnet/api/system.console.readkey)
- [`Console.Title`](https://docs.microsoft.com/en-us/dotnet/api/system.console.title)