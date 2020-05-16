# Hello World!

In this lecture, we will learn how to create the simplest C# console application. First, we will cover the actual source code required to program the application. Second, we will cover how to create such a project and run it using the .NET Core Framework. References to any C# code used are listed at the bottom of this document.

## Setup

In order to run the code in this lecture, the following command must be entered at the command line from the root of the repository. (Note that for all specified commands, the `$` symbol denotes the prompt and should not be typed out.)

```bash
$ cd lectures/1-variables/1-hello-world/
```

This simply changes the directory that we refer to with other commands.

## Hello World Program

As per the tradition of programming tutorials, we must start with a "Hello World" example. We will be writing a simple **console application**, an application that writes output and takes input from a terminal interface. The application will print the statement "Hello World!" and end.

The following code sample shows the simplest version of such a program. (This code is already provided for you in the `Program.cs` file.)

#### `Program.cs`
```csharp
using System;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello World!");
    }
}
```
Much of the code listed here is **boilerplate** or parts of code required for many applications with little change. However, only a small portion of the code is currently relevant to us. For the current section of lectures, we will only be concerned with the code in the innermost set of curly braces `{}`.

```csharp
Console.WriteLine("Hello World!");
```

This single line of code is what displays the statement "Hello World!" to the screen when we run it. Let's disassemble it!

1. The `Console` token represents that we are performing an operation on the `Console` object. In our case, this refers to the command line or terminal.
2. The `WriteLine` token represents the action of writing a line of text to the `Console`.
3. The `"Hello World!"` token is the line of text that we would like to write to the `Console`. We will learn later that this is called a string. What is important for now is that the text we want to write must be enclosed by a set of double quotes `""`.
4. The semicolon `;` ends our line of code. All lines of C# code must be ended with a semicolon or the code will have invalid syntax.

We will learn more about some of the specific syntactic elements later. For now, let's run the code.

## Running Code

In order to perform any action using the .NET Core Framework, we use the `dotnet` command at the terminal. There are many possible actions that this command provides but we will only need a few.

To set up this project, we used the following command. (Note that this is already set up for you. You **do not** need to run this command.)
```bash
$ dotnet new console
```
The `new` action specifies that we will be creating a new project and the `console` option specifies that the new project should be a console application.

To run our project, we use the following command  which produces the specified output.
```bash
$ dotnet run
Hello World!
```
The `run` action is what we will most commonly use and specifies that the project in the current directory should be run using the .NET Core Framework.

## Exercises

Perform the following modifications to the provided code. Then, execute the code using the `dotnet run` command and check your work.

1. Change the code in order to make the application print `"Hello C#"`.
2. Add another line of code to make the application print `"Hello C#"` on one line and `"Welcome, user."` on a second line. 
3. Use the following line of code *before* your `WriteLine` statements to change the text color to green.
    ```csharp
    Console.ForegroundColor = ConsoleColor.Green;
    ```
    Then, use the following line of code *after* your `WriteLine` statements to reset the text color.
    ```csharp
    Console.ResetColor()
    ```

### Links
[Home](../../../readme.md)

### References
- [`Console.WriteLine`](https://docs.microsoft.com/en-us/dotnet/api/system.console.writeline)
- [`Console.ForegroundColor`](https://docs.microsoft.com/en-us/dotnet/api/system.console.foregroundcolor)
- [`Console.BackgroundColor`](https://docs.microsoft.com/en-us/dotnet/api/system.console.backgroundcolor)
- [`Console.ResetColor`](https://docs.microsoft.com/en-us/dotnet/api/system.console.resetcolor)
- [`ConsoleColor`](https://docs.microsoft.com/en-us/dotnet/api/system.consolecolor)