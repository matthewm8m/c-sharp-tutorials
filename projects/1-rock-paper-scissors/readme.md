# Rock Paper Scissors

In this project, you will design a simple application that allows the user to play the game of Rock Paper Scissors with a random acting computer. This project will test your understanding of user input and logical operations.

## Prerequisites

The following lectures contain information that is strictly necessary to know for completing this project. It should not be necessary to use any concepts that have not been covered up to this point.

- [1-1: Hello World!](../../lectures/1-variables/1-hello-world/)
- [1-3: Variables](../../lectures/1-variables/3-variables/)
- [1-5: Operations](../../lectures/1-variables/5-operations/)
- [1-8: Input](../../lectures/1-variables/8-input/)
- [1-11: Random](../../lectures/1-variables/11-random/)
  
## Background

In this section, relevant information to this project is presented so that you have all necessary knowledge to implement this project.

### Rock Paper Scissors

The game of Rock Paper Scissors involves two players that independently select one of three symbols: a rock, a paper, or scissors. Players win, lose, or tie based on the combination of symbols:

- Player 1 picks rock; Player 2 picks scissors; Player 1 wins.
- Player 1 picks scissors; Player 2 picks paper; Player 1 wins.
- Player 1 picks paper; Player 2 picks rock; Player 1 wins.

If both players pick the same symbol, then, they tie. If a player does not win nor tie, then, the player loses.

### Random Number Generation

In order to test that the solution to the project is working as expected, we need to allow for seeding the random number generator from outside the application. The following code allows us to do this. Please use this code snippet at the beginning your code to properly obtain a seed.

```csharp
/*
    This section of code retrieves a seed for the random number
    generation that can be passed in from the command line. You do not
    need to worry about how this code works currently.
*/
string seedString = args.Length > 0 ? args[0] : String.Empty;
int seed = String.IsNullOrEmpty(seedString) ?
    (new Random()).Next() : Convert.ToInt32(seedString);
```

Then, you may create a random number generator as previously discussed.

```csharp
Random rng = new Random(seed);
```

You do not need to understand how this seed generation code segment works.

### String Equality

In this project, you will need to test if two `string` values are equal. Previously we discussed the equality check operator `==`. However, this operator will not work in this circumstance. Instead, we need to use the `Equals` method. For instance, to check that `string1` and `string2` are equal, we use the following code:

```csharp
string string1;
string string2;
bool areEqual = string1.Equals(string2);
```

## Requirements

Create a simple application that prompts the user for a choice from Rock Paper Scissors and compete it against a random choice made by a computer. Then, output the results. The following list is a detailed description of each step of the program in order:

1. Prompt the user with the question `"Rock, paper, or scissors?"` on its own line.
2. Collect the user input on the next line. Valid inputs include `string` values such as `"rock"`, `"PAPER"`, or `"sCiSsoRs"`. That is, any case variant of the `string` values `"rock"`, `"paper"`, and `"scissors"`.
   
    *Hint: You can use `stringValue.ToLower()` to convert a `string` to a lowercase form. For example:*
    ```csharp
    string stringValue = "a StRiNG!";
    string stringValueLowercase = stringValue.ToLower();

    // Outputs "a string!".
    Console.WriteLine(stringValueLowercase);
    ```
3. Generate a random integral value `0`, `1`, `2` representing rock, paper, and scissors respectively for the computer's choice.
4. Display both the player's and computer's choice of symbol on separate lines.
   
    The first line should be of the form:
    ```csharp
    "You chose scissors."
    ```
    where the choice is the lowercase form of what the user entered (even if the input was invalid).

    The second line should be of the form:
    ```csharp
    "The computer chose rock."
    ```
    where the choice is the lowercase form of what the computer randomly generated.
5. Output who won the game on a new line.
    - If the user entered an invalid input, output
  
        ```csharp
        "No winner. Invalid input."
        ```
    
    - If the player won, output

        ```csharp
        "You win!"
        ```

    - If the computer won, output

        ```csharp
        "The computer wins!"
        ```

    - If the player and computer tied, output

        ```csharp
        "You tied!"
        ```

Here are two examples of an entire program running:
```
Rock, paper, or scissors?
PAPER
You chose paper.
The computer chose rock.
You win!
```

```
Rock, paper, or scissors?
tissue
You chose tissue.
The computer chose paper.
No winner. Invalid input.
```

It is important that the syntax and outputs match of your program exactly with what is defined here. Otherwise, the tests for the functionality of the program will fail.

## Setup

In order to run code from and test this project, the following command must be entered at the command line from the root of the repository. (Note that for all specified commands, the `$` symbol denotes the prompt and should not be typed out.)

```bash
$ cd projects/1-rock-paper-scissors/
```

This simply changes the directory that we refer to with other commands.

This directory contains three other directories: `RockPaperScissors/`, `Solution/`, and `Tests/`.
- `RockPaperScissors/` contains a blank project for you to implement the project. All programming for this project should be done in this directory. We will discuss executing this project in the next section.
- `Solution/` contains a solution to the project. It is in your best interest to solve the project completely first and then check the solution to see another perspective on the project. To run the solution instead of your project, you can copy all of the files from `Solution/` into `RockPaperScissors/`.
- `Tests/` contains tests to make sure the project is working correctly. You should not modify any of the code in this directory. We will discuss testing in the next section.

## Execution/Testing

In order to run the project contained in the `RockPaperScissors/` directory, simply run the following command. This can be used to manually check that the program is running correctly.

```bash
$ dotnet run --project RockPaperScissors
```

There are automated tests associated with this project contained in the `Tests/` directory. To run these tests, execute the following command.

```bash
$ dotnet test Tests
```

The command will tell you which tests passed or failed and how the output produced by your program differs from the expected output. You should only consider the project complete if all tests pass.

## Links
[Home](../../readme.md) |
[Project 2](../../projects/2-scale-calculator/)

## References
- [Rock Paper Scissors](https://en.wikipedia.org/wiki/Rock_paper_scissors)