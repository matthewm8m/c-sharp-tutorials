# Musical Scale Calculator

In this project,

In this project, you will design a simple application that allows the user to play the game of Rock Paper Scissors with a random acting computer. This project will test your understanding of user input and logical operations.

## Prerequisites

The following lectures contain information that is strictly necessary to know for completing this project. It should not be necessary to use any concepts that have not been covered up to this point.

- [1-1: Hello World!](../../lectures/1-variables/1-hello-world/)
- [1-3: Variables](../../lectures/1-variables/3-variables/)
- [1-5: Operations](../../lectures/1-variables/5-operations/)
- [1-7: Math](../../lectures/1-variables/7-math/)
- [1-8: Input](../../lectures/1-variables/8-input/)
- [1-9: Conversion](../../lectures/1-variables/9-conversion/)
- [1-10: Output](../../lectures/1-variables/10-output/) 

## Background

In this section, relevant information to this project is presented so that you have all necessary knowledge to implement this project.

### Music

In this project, we will need to know some concepts of music theory. We will treat the music theory as a purely mathematical construct. So, we will not discuss specific notes; instead, we will discuss a **tone** which is anything audible with a specific frequency.

#### Octaves

An octave is the interval starting at a particular musical **tone** and ending with the same tone with double the frequency. In western music, there are 12 musical **semitones** that span the octave and includes the endpoints. The frequency of each semitone can be computed using the exponential frequency of an octave. For example, given that an octave starts on a tone with frequency 440 Hz, the 4th semitone of the octave has a frequency given by:

```
440 Hz * 2^(1/3) = 554 Hz
```

Part of your job will be to generalize this formula for the implementation of this project.

#### Major Scale

A **major scale** is a common musical scale or sequence of tones that has a simple pattern. We will refer to a difference of 1 semitone between tones as a **half step** and a difference of 2 semitones between tones as a **whole step**. Using these definitions, a major scale starting with some base tone can be constructed using the following sequence of steps:

*Whole, Whole, Half, Whole, Whole, Whole, Half*

Thus, the base tone is the 0th semitone of the octave, the 2nd scale tone is the 2nd semitone of the octave, and the 7th scale tone is the 11th semitone of the octave.

#### Minor Scale

Similar to a major scale, a minor scale can be constructed using a sequence of steps:

*Whole, Half, Whole, Whole, Half, Whole, Whole*

Thus, the base tone is the 0th semitone of the octave, the 2nd scale tone is the 2nd semitone of the octave, and the 7th scale tone is the 10th semitone of the octave.

### String Equality

In this project, you will need to test if two `string` values are equal. Previously we discussed the equality check operator `==`. However, this operator will not work in this circumstance. Instead, we need to use the `Equals` method. For instance, to check that `string1` and `string2` are equal, we use the following code:

```csharp
string string1;
string string2;
bool areEqual = string1.Equals(string2);
```

## Requirements

Create an application that can generate a major or minor scale starting with a tone with a frequency specified by the user. The application should input whether the scale should be major or minor. The output will be all 8 notes, including the base note, that make up the scale. The following list is a detailed description of each step of the program in order:

1. Prompt the user with the question `"Would you like to calculate a major or minor scale?"` on its own line.
2. Collect the user input for the type of scale on the next line. Valid inputs include `string` values such as `"major"`, `"MINOR"`, or `"MaJoR"`. That is, any case variant of the `string` values `"major"` or `"minor"`.
   
    *Hint: You can use `stringValue.ToLower()` to convert a `string` to a lowercase form. For example:*
    ```csharp
    string stringValue = "a StRiNG!";
    string stringValueLowercase = stringValue.ToLower();

    // Outputs "a string!".
    Console.WriteLine(stringValueLowercase);
    ```
3. Prompt the user with the phrase `"Enter the starting frequency (in Hz):"` on its own line.
4. Collect the user input for the frequency on the next line. This should be converted to a floating-point value.
5. Each of the 8 frequencies for the specified musical scale should be calculated and displayed to the user in the format `"Note {note number}: {note frequency}"` *rounded to 2 decimal places*. Each note should appear on a separate line.
   
   If either of the user inputs are invalid (i.e. the scale was not major or minor or the frequency was not a number), then display `"Invalid input."` instead of any note outputs.

Here are three examples of an entire program running:
```
Would you like to calculate a major or minor scale?
major
Enter the starting frequency (in Hz):
440
Note 1: 440.00
Note 2: 493.88
Note 3: 554.37
Note 4: 587.33
Note 5: 659.26
Note 6: 739.99
Note 7: 830.61
Note 8: 880.00
```

```
Would you like to calculate a major or minor scale?
MINOR
Enter the starting frequency (in Hz):
352.04
Note 1: 352.04
Note 2: 395.15
Note 3: 418.65
Note 4: 469.92
Note 5: 527.46
Note 6: 558.83
Note 7: 627.26
Note 8: 704.08
```

```
Would you like to calculate a major or minor scale?
major
Enter the starting frequency (in Hz):
not a number
Invalid input.
```

It is important that the syntax and outputs match of your program exactly with what is defined here. Otherwise, the tests for the functionality of the program will fail.

## Setup

In order to run code from and test this project, the following command must be entered at the command line from the root of the repository. (Note that for all specified commands, the `$` symbol denotes the prompt and should not be typed out.)

```bash
$ cd projects/2-scale-calculator/
```

This simply changes the directory that we refer to with other commands.

This directory contains three other directories: `ScaleCalculator/`, `Solution/`, and `Tests/`.
- `ScaleCalculator/` contains a blank project for you to implement the project. All programming for this project should be done in this directory. We will discuss executing this project in the next section.
- `Solution/` contains a solution to the project. It is in your best interest to solve the project completely first and then check the solution to see another perspective on the project. To run the solution instead of your project, you can copy all of the files from `Solution/` into `RockPaperScissors/`.
- `Tests/` contains tests to make sure the project is working correctly. You should not modify any of the code in this directory. We will discuss testing in the next section.

## Execution/Testing

In order to run the project contained in the `ScaleCalculator/` directory, simply run the following command. This can be used to manually check that the program is running correctly.

```bash
$ dotnet run --project ScaleCalculator
```

There are automated tests associated with this project contained in the `Tests/` directory. To run these tests, execute the following command.

```bash
$ dotnet test Tests
```

The command will tell you which tests passed or failed and how the output produced by your program differs from the expected output. You should only consider the project complete if all tests pass.

## Links
[Home](../../../readme.md) |
[Project 1](../../../projects/1-rock-paper-scissors/)

## References
- [Octaves](https://en.wikipedia.org/wiki/Octave)
- [Musical Scales](https://en.wikipedia.org/wiki/Scale_(music))