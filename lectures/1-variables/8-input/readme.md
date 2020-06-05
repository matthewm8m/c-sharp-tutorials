# Input

In this lecture, we will learn how to read input text from the user. We will discuss three different methods of collecting inputs, one of which reads entire lines while the other two methods read single characters.

## Setup

In order to run the code in this lecture, the following command must be entered at the command line from the root of the repository. (Note that for all specified commands, the `$` symbol denotes the prompt and should not be typed out.)

```bash
$ cd lectures/1-variables/8-input/
```

This simply changes the directory that we refer to with other commands.

## Input

Up until this point, we have written code that requires no input from the user. This is fine for some types of applications that perform heavy computations or require no user interactions. However, we often want to receive some input from the user to initialize the program or change the flow of execution as a program is running. In order to do this, we need to collect user input. Just as C# provides methods of writing output using `Console.WriteLine` and `Console.Write`, we also have access to methods of reading input using `Console.ReadLine` and `Console.ReadKey`.

### Reading Lines

The simplest method of reading user input is to collect an entire line at the terminal and store it in a string. That is, every character that the user types in until the enter key is pressed is recorded. We use the `Console.ReadLine` method to achieve this. For example, the following code snippet prompts for the user's name and uses `Console.ReadLine` to collect it.

```csharp
Console.Write("Enter your name: ");
string userName = Console.ReadLine();
```

We note that the type of value returned from `Console.ReadLine` is always `string`. Therefore, we *cannot* input a numerical value directly and the following code snippet will *not* work.

```csharp
Console.Write("Enter your favorite number: ");
// Error: Return type is `string` not `int`.
int favoriteNumber = Console.ReadLine();      
```

We discuss the appropriate methods to perform this conversion from a `string` to an `int` in the next lecture.

### Reading Characters

Instead of reading in an entire line from the terminal, we can use the `Console.ReadKey` method to read a single character instead. The `Console.ReadKey` method actually returns a value of type `ConsoleKeyInfo`. We will ignore most of the complexities of this type for now. What is important to us is that the `ConsoleKeyInfo` type has a `KeyChar` **property**, a subvalue stored within a type, which represents the `char` value that the user entered into the terminal. The following code snippet shows an example of collecting a single character from the user and redisplaying it.

```csharp
// Get the entered character.
ConsoleKeyInfo inputKey = Console.ReadKey();
char inputChar = inputKey.KeyChar;

// Redisplay that character.
Console.Write("You entered: ");
Console.WriteLine(inputChar);
```

We can also shorten the `Console.ReadKey` method and `KeyChar` into a single statement like so:

```csharp
char inputChar = Console.ReadKey().KeyChar;
```

So far, we have used the `Console.ReadKey` method without any parameters passed in. However, we can also specify a `bool` value that specifies whether the character should be intercepted or written to the terminal. That is,

```csharp
char input;

// Inputs a character from the user but does not display it.
input = Console.ReadKey(true).KeyChar;

// Inputs a character from the user and does display it. 
input = Console.ReadKey(false).KeyChar;
```

## Exercises

A program demonstrating the use of the user input is provided as `Program.cs`. Read through this example program and run it using the `dotnet run` command.

Modify the provided code to implement the following exercises. Then, execute the code using the `dotnet run` command and check your work.

1. Another property of the `ConsoleKeyInfo` type is the `Modifiers` property. The `Modifiers` property is a value of type `ConsoleModifiers`. In this example we will be checking whether the shift key was being pressed when the character was entered. We can check this using the statement:
    ```csharp
    var inputKey = Console.ReadKey(true);
    bool isShiftPressed = inputKey.Modifiers == ConsoleModifiers.Shift;
    ```
    We can also the `Char.ToUpper` method for `char` types to turn a lowercase value to an uppercase value using the statement:
    ```csharp
    char lowercaseChar = 'a';
    char uppercaseChar = Char.ToUpper(lowercaseChar);
    ```
    We will use these statements to ensure that the middle initial of the user is capitalized. Modify the existing code using `isShiftPressed` and a conditional operator `?:` in order to make the input character uppercase **only if** the shift key was not pressed.

    Test this by entering a lowercase character and observing the adjusted output.

    *Note: Obviously, we can just use*
    ```csharp
    middleInitial = Char.ToUpper(middleInitial);
    ```
    *to make the initial uppercase without checking `isShiftPressed`. However, the point of this exercise it to practice manipulating user input.*
2. The final property of the `ConsoleKeyInfo` is the `Key` property. The `Key` property is a value of type `ConsoleKey`. We will check if the user has pressed a specific key; namely, we will check if they pressed the escape key using the following statement:
    ```csharp
    bool isEscapePressed = inputKey.Key == ConsoleKey.Escape;
    ```
    Add a section to the end of the program that prompts the user to press the escape key. Then, display the message "You did it!" only if they pressed the escape key. Otherwise, display nothing at all.

    *Hint: Use the conditional `?:` operator.*

### Links
[Previous](../7-math/) |
[Home](../../../readme.md) |
[Next](../9-conversion/)

[Project 1](../../../projects/1-rock-paper-scissors/) |
[Project 2](../../../projects/2-octave-calculator/)

### References
- [`Console`](https://docs.microsoft.com/en-us/dotnet/api/system.console)
  - [`Console.ReadLine`](https://docs.microsoft.com/en-us/dotnet/api/system.console.readline)
  - [`Console.ReadKey`](https://docs.microsoft.com/en-us/dotnet/api/system.console.readkey)
- [`ConsoleKeyInfo`](https://docs.microsoft.com/en-us/dotnet/api/system.consolekeyinfo)
  - [`ConsoleKeyInfo.KeyChar`](https://docs.microsoft.com/en-us/dotnet/api/system.consolekeyinfo.keychar)
  - [`ConsoleKeyInfo.Key`](https://docs.microsoft.com/en-us/dotnet/api/system.consolekeyinfo.key)
  - [`ConsoleKeyInfo.Modifiers`](https://docs.microsoft.com/en-us/dotnet/api/system.consolekeyinfo.modifiers)
- [`ConsoleKey`](https://docs.microsoft.com/en-us/dotnet/api/system.consolekey)
- [`ConsoleModifiers`](https://docs.microsoft.com/en-us/dotnet/api/system.consolemodifiers)
- [`Char`](https://docs.microsoft.com/en-us/dotnet/api/system.char)
  - [`Char.ToUpper`](https://docs.microsoft.com/en-us/dotnet/api/system.char.toupper)
  - [`Char.ToLower`](https://docs.microsoft.com/en-us/dotnet/api/system.char.tolower)