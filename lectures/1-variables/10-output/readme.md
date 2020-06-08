# Output

In this lecture, we will discuss various methods of creating advanced `string` values and using formatting in our outputs. We discuss the escape sequence syntax used to represent formatting or syntactic characters. We discuss the fundamentals of C#'s composite formatting and generalize the syntax to `string` interpolation. We will look through numerous examples that exhibit how these features are used in applications.

## Setup

In order to run the code in this lecture, the following command must be entered at the command line from the root of the repository. (Note that for all specified commands, the `$` symbol denotes the prompt and should not be typed out.)

```bash
$ cd lectures/1-variables/10-output/
```

This simply changes the directory that we refer to with other commands.

## Escape Sequences

So far, our `string` values have been very simple. They have consisted of a short phrase or prompt but have required no extra formatting. However, it turns out that with our current knowledge of `string` values, some particular characters are impossible to represent. For example, in a `string`, we cannot use the double quote `"` character because it represents the start and end points of the `string` itself.
```csharp
// Invalid. Raises error because `text` appears to be outside of the string.
string invalidString = "Some "text"";
```
Or, we might want to have a `char` that stores the single quote `'` character. But this is also a delimeter for the `char` type literal this time.
```csharp
// Invalid. Raises error because there are unmatched single quotes.
char invalidChar = ''';
```
To solve this problem, we make the use of **escape sequences**, sequences of coded characters starting with a backslash `\` that denotes a single character. The following are the common escape sequences representing literal characters.
- `'\''` (Literal single quote) - Represents the `'` character.
- `'\"'` (Literal double quote) - Represents the `"` character.
- `'\\'` (Literal backslash) - Represents the `\` character.
For instance, we can rewrite our problematic cases using escape characters now:
```csharp
string validString = "Some \"text\"";
char validChar = '\'';
```
In addition, since we now know that backslashes `\` mark the start of escape sequences, we have to use the backslash escape sequence to represent a backslash itself:
```csharp
char backslashChar = '\\';
```

We have relied on the distinction between `Console.Write` and `Console.WriteLine` to determine whether we should move to the next line after writing some text. Currently, we do not have very much flexibility with our output capabilities. So, we can use escape sequences to insert formatting characters into our `string` values. Here are the most important escape sequences.

- `'\n'` (New line) - Moves to the next line. For example,
    ```csharp
    Console.Write("Here\nis some\ntext");
    ```
    outputs
    ```
    Here
    is some
    text
    ```
- `'\r'` (Line/Carriage Return) - Moves the cursor to the beginning of the line. This does not move the cursor onto the next line. For example,
    ```csharp
    Console.WriteLine("Hello World\rAloha");
    ```
    outputs
    ```
    Aloha World

    ```
    As a side note, if we do not move to the next line after a line return, the terminal may overwrite some text because the cursor remains at the same location even after the program exits.
- `'\b'` (Backspace) - Moves the cursor backwards one character non-destructively. That is, the location of the next character is moved backward one space but the character at that location is not removed. For example,
    ```csharp
    Console.WriteLine("12\b345");
    Console.WriteLine("ab\b\bc");
    ```
    outputs
    ```
    1345
    cb

    ```
- `'\t'` (Tab) - Moves the cursor forward to the next tab division (usually spacings of 8 characters are used). This is commonly used for outputting tables. For example,
    ```csharp
    Console.WriteLine("123\tabc");
    Console.WriteLine("12345678\tabcdefghi");
    Console.WriteLine("26\tz");
    ```
    outputs
    ```
    123     abc
    12345678        abcdefghij
    26      z
    ```
- `'\a'` (Alert) - Outputs an audible beep to the terminal. This can be used to indicate that a process has finished or that an invalid operation was attempted. For example,
    ```csharp
    Console.Write("\a");
    ```
    outputs no text but a beep should be produced.

Using these formatting escape sequences, we can identify the difference between `Console.Write` and `Console.WriteLine`. By convention, moving to the next line is defined as outputting the `'\r'` and `'\n'` characters. Thus, the following pairs of statements are equivalent.
```csharp
Console.WriteLine();
Console.Write("\r\n");
```
and
```csharp
Console.WriteLine(value);
Console.Write(value.ToString() + "\r\n");
```
where the `+` represents `string` concatenation as dicussed in previous lectures.

## Formatting

Previously, we have encountered many situations where we switch between outputting text and outputting variables. For instance,
```csharp
var sumItems = 25d;
var numItems = 4;
var average = sumItems / numItems;

Console.Write("The average of the ");
Console.Write(numItems);
Console.Write(" items is ");
Console.Write(average);
Console.WriteLine(".");
```
In this section, we will introduce **composite formatting** which can mix text and variables together. Using composite formatting, the write statements in the previous example can be compressed to
```csharp
Console.WriteLine("The average of the {0} items is {1}.", numItems, average);
```
Obviously, this is much more concise and readable. Now we will discuss the syntax involved in composite formatting.

To start a formatted item, we use the format
```
{index,aligment:format}
```
where `alignment` and `format` are optional.

Notice that the composite formatting notation begins with an opening curly brace `{` and ends with a closing curly brace `}`. Just like the literal escape code for a backslash (`'\\'`), we need a way to represent the curly braces `{}` literally without creating a format item. To do this, we use a double curly brace `{{` or `}}` to represent `'{'` and `'}'` respectively. Thus, the following code
```csharp
Console.Write("{{0}}", 50);
```
outputs
```
{0}
```

### Index

The `index` part of a format item is required. It is a positive `int` that specifies the position of the proceding values to substitute in that place starting with zero. For example,
```csharp
Console.Write("{0} {1} {2}", 1, 2, 3);
```
outputs
```
1 2 3
```
Because the value in position `0` is `1`, the value in position `1` is `2`, and the value in position `2` is `3`.

We can use any index in any order and any number of times. So, the code
```csharp
Console.Write("{3}, {2} {1} {0} {1} {2} {3}?", "glad", "you", "are", "king");
```
produces
```
king, are you glad you are king?
```

If there is not a value for a corresponding `index`, then, a formatting error is raised. This is the case in the following code snippet:
```csharp
// Error. There is no 51st value.
Console.Write("{0} and {50}", "Hello", "goodbye");
```

### Alignment

The `alignment` part of a format item is another `int` that specifies how to align the value and how much space to give it. If the alignment is positive, the value is right aligned. If the alignment is negative, the value is left aligned.

If the length of the `string` representation of a variable is greater than the magnitude of the `alignment` part, the alignment is ignored. If the string representation of a value is shorter than the magnitude of the `alignment` part, then the remaining space is filled with empty spaces. Here are some examples of alignment:

A tabulated list of names can be created using the code
```csharp
Console.WriteLine("{0,-16}{1,16}", "First Name", "Last Name");
Console.WriteLine();
Console.WriteLine("{0,-16}{1,16}", "Jane", "Doe");
Console.WriteLine("{0,-16}{1,16}", "John", "Doe");
Console.WriteLine("{0,-16}{1,16}", "Robert", "Smith");
```
which outputs
```
First Name             Last Name

Jane                         Doe
John                         Doe
Robert                     Smith
```

Using alignment is particularly useful when creating tables of results because it allows for easily specifying column widths.

### Format

The final component to any formatted item is the `format` part. It is a combination of characters and numbers that define specific formatting for particular data types. We will discuss the most commonly used numeric, date, and time `format` components.

#### Numbers

In the following `format` specifiers, `#` represents an arbitrary positive integer. These specifiers are the ones that are primarily used for numeric values:

- `D#` (Decimal) - For integral values where `#` is the number of digits to fill in padded with zeros. The specifier `D6` for `42` produces `"000042"`.
- `F#` (Fixed-point) - For integral or floating-point values where `#` is the number of decimal places padded with zeros. The specifier `F3` for `111.2` produces `"111.200"`.
- `E#` (Exponential) - For integral or floating-point values where `#` is the number of decimal places padded with zeros. This specifies an exponential notation with a positive or negative exponent that has 3 digits. The specifier `E4` for `42560.15` is `"4.2560E+004"`.
- `G#` (General) - For integral or floating-point values where `#` is the number of decimal places padded with zeros. This is equivalent to either the fixed-point or exponential specifier: whichever produces a shorter string.
- `C#` (Currency) - For integral or floating-point values that specifies a currency where `#` specifies the number of decimal places padded with zeros. The specifier `C2` for `123.456` produces `"$123.46'`.
- `P#` (Percent) - For integral or floating-point values that specifies a percentage where `#` specifies the number of decimal places padded with zeros. The specifier `P2` for `0.20455` produces `"20.46%"`.

Here is an example of displaying the cost of an item:
```csharp
decimal itemCost = 20.49m;
Console.WriteLine("The cost of this item is {0:C2}.", itemCost);
```
which outputs
```
The cost of this item is $20.49.
```

Here is an example of displaying an interest rate as a percentage with 2 decimal places:
```csharp
decimal interestRate = 0.0850m;
Console.WriteLine("Interest Rate: {0:P2}", interestRate);
```
which outputs
```
Interest Rate: 8.50%
```

#### Dates and Times

Both dates and times are represented in a unified value using the `DateTime` type. We will not dig too much into this type right now but it is useful in learning to format values. Please note that not all computers will exhibit the same behavior especially if the computer is located in a non-North American country. The behavior discussed here will always be *similar* but not necessarily *identical* in other locales.

We note that one of the most important `DateTime` values to work with is the one represents the current date and time which can be obtained in the following way:

```csharp
DateTime now = DateTime.Now;
```

We will assume the following notation for the rest of this section (these are the symbols used for custom formats):
- `M` - represents the month number.
- `MMM` - represents the abbreviated name of the month.
- `MMMM` - represents the full name of the month.
- `d` - represents the day of the month number.
- `ddd` - represents the abbreviated name of the day of the week.
- `dddd` - represents the full name of the day of the week.
- `yy` - represents the last 2 digits of the year.
- `yyyy` - represents the full 4 digits of the year.
- `h` - represents the hour on a 12-hour clock.
- `mm` - represents the minute of the hour.
- `ss` - represents the second of the minute.
- `tt` - represents whether the time is AM or PM.

As a specific instance of now, we will assume that the date is June 4, 2020 and the time is 3:31 PM. The following `format` options are commonly used to display useful representations of dates and times: 
- `d` (Short date) - A shortcut for `M/d/yyyy`. In our instance, `6/4/2020`.
- `D` (Long date) - A shortcut for `dddd, MMMM d, yyyy`. In our instance, `Thursday, June 4, 2020`.
- `M` (Month and day) - A shortcut for `MMMM d`. In our instance, `June 4`.
- `Y` (Month and year) - A shortcut for `MMMM yyyy`. In our instance, `June 2020`.
- `t` (Short time) - A shortcut for `h:mm tt`. In our instance, `3:31 PM`.
- `T` (Long time) - A shortcut for `h:mm:ss tt`. In our instance, `3:31:01 PM`.

Here is an example of using these `format` specifiers to notify the user of the date and the time:

```csharp
Console.WriteLine("It is currently {0:D} at {0:t}.", DateTime.Now);
```
outputs
```
It is currently Thursday, June 4, 2020 at 3:31 PM.
```

There are some more advanced methods to perform custom formatting for specific types. However, we will not discuss them here as they are not usually necessary.

Combining everything together, we can write highly customizable output statements. For example, suppose that we have some input to the `Math.Sin` function named `x`. The output of the function is `y`. We can tabulate a few `x`, `y` pairs with 4 decimal places of precision:
```csharp
Console.WriteLine("{0,-8}{1,8}", "x", "y");
Console.WriteLine();
Console.WriteLine("{0,-8:F4}{1,8:F4}", 0.00, Math.Sin(0.00));
Console.WriteLine("{0,-8:F4}{1,8:F4}", 0.25, Math.Sin(0.25));
Console.WriteLine("{0,-8:F4}{1,8:F4}", 0.50, Math.Sin(0.50));
Console.WriteLine("{0,-8:F4}{1,8:F4}", 0.75, Math.Sin(0.75));
Console.WriteLine("{0,-8:F4}{1,8:F4}", 1.00, Math.Sin(1.00));
```
produces the output
```
x              y

0.0000    0.0000
0.2500    0.2474
0.5000    0.4794
0.7500    0.6816
1.0000    0.8415
```

## String Interpolation

We can make string formatting more concise and generalizable. This is made possible using C#'s string interpolation feature. Continuing with the averaging example we introduced earlier,
```csharp
Console.WriteLine("The average of the {0} items is {1}.", numItems, average);
```
can be further condensed to
```csharp
Console.WriteLine($"The average of the {numItems} items is {average}.");
```
which is even clearer and more concise.

This is done by replacing the `index` part of each format item with its corresponding value and prefixing the `string` with a dollar sign `$`. For example, to convert
```csharp
Console.Write("{1}{2}{0}{1}", 1, 2, 3);
```
to string inpolation form, we replace `"{0}"` with `1`, `"{1}"` with `2`, and `"{2}"` with `3`. Finally, we prefix the `string` with `$`. This results in
```csharp
Console.Write($"{2}{3}{1}{2}");
```
which outputs
```
2312
```

However, string formatting is no longer restricted to the use of `Console.Write` and `Console.WriteLine`. Now, we can apply formatting to arbitrary strings. For instance:
```csharp
decimal cost = 9.99m;
decimal taxPercent = 0.05m;
string costString = $"{cost:C2} + {cost * taxPercent:C2}";

Console.WriteLine($"Cost + Tax: {costString}");
```
which outputs
```
Cost + Tax: $9.99 + $0.50
```

Functionally, composite formatting and string interpolation are the same procedure just with different syntaxes. Thus, the following statements are equivalent.

```csharp
var formatted = String.Format("{0} {1} {2}", value1, value2, value3);
var formatted = $"{value1} {value2} {value3}";
```

In this code snippet, `String.Format` is the method that formats strings based on the rules described for composite formatting.

## Exercises

A blank program file is provided as `Program.cs`. Implement the following exercises in this blank program. Then, execute the code using the `dotnet run` command and check your work.

1. Prompt the user for a number of **seconds** to wait until an alarm sound chimes. Then, use
    ```csharp
    Thread.Sleep(millisecondsToWait);
    ```
    to wait a certain number of **milliseconds** where `millisecondsToWait` is an `int` based on the user input. Then, use `Console.Write` and `Thread.Sleep` statements with escape sequences to make an alarm sound 3 times with a delay of half a second between each sound. If the user input was invalid display an error message **immediately** and do not make an alarm sound.

    *Hint 1: The conditional operator `:?` is your friend.*

    *Hint 2: Sleeping for zero milliseconds has no impact on the program.* 
2. Before prompting the user for a wait time, add a welcome for the user and display the time, *in long time format*, in a single `string` using composite formatting.
3. Before welcoming the user, prompt the user for their name and store it. Then, modify the welcome message to include the username using string interpolation. You should end up with a welcome message displayed by a single `Console.Write` statement that uses **both** composite formatting and string interpolation. The program should exit on an empty line.

    *Hint: You may need to escape the curly braces `{}`.*

### Links
[Previous](../9-conversion/) |
[Home](../../../readme.md) |
[Next](../11-random/)

[Project 1](../../../projects/1-rock-paper-scissors/) |
[Project 2](../../../projects/2-octave-calculator/)

### References
- [Escape Sequences](https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences)
- [Composite Formatting](https://docs.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting)
  - [Date Formatting](https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-date-and-time-format-strings)
  - [Numeric Formatting](https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings)
- [String Interpolation](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated)
- [`Console`](https://docs.microsoft.com/en-us/dotnet/api/system.console)
  - [`Console.Write`](https://docs.microsoft.com/en-us/dotnet/api/system.console.write)
  - [`Console.WriteLine`](https://docs.microsoft.com/en-us/dotnet/api/system.console.writeline)
- [`DateTime`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime)
  - [`DateTime.Now`](https://docs.microsoft.com/en-us/dotnet/api/system.datetime.now)
- [`Thread.Sleep`](https://docs.microsoft.com/en-us/dotnet/api/system.threading.thread.sleep)