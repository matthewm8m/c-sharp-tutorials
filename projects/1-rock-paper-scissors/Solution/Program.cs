using System;

namespace RockPaperScissors
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
                This section of code retrieves a seed for the random number
                generation that can be passed in from the command line. You do not
                need to worry about how this code works currently.
            */
            string seedString = args.Length > 0 ? args[0] : String.Empty;
            int seed = String.IsNullOrEmpty(seedString) ?
                (new Random()).Next() : Convert.ToInt32(seedString);

            /*
                We use these values to switch between the strings:
                    "rock", "paper", "scissors"
                and the integers
                    0, 1, 2
            */
            const int ROCK_VALUE = 0;
            const int PAPER_VALUE = 1;
            const int SCISSORS_VALUE = 2;

            // Get the player choice.
            // We will use a value of -1 to represent an invalid input.
            Console.WriteLine("Rock, paper, or scissors?");
            string playerString = Console.ReadLine().ToLower();
            int playerChoice = -1;
            playerChoice = playerString.Equals("rock") ?
                ROCK_VALUE : playerChoice;
            playerChoice = playerString.Equals("paper") ?
                PAPER_VALUE : playerChoice;
            playerChoice = playerString.Equals("scissors") ?
                SCISSORS_VALUE : playerChoice;

            // Generate the computer choice.
            var rng = new Random(seed);
            int computerChoice = rng.Next(3);
            string computerString = "";
            computerString = computerChoice == ROCK_VALUE ?
                "rock" : computerString;
            computerString = computerChoice == PAPER_VALUE ?
                "paper" : computerString;
            computerString = computerChoice == SCISSORS_VALUE ?
                "scissors" : computerString;

            // Decide the winner of the game.
            // Notice that if player choice - computer choice is 1 using remainder
            // 3, then player wins.
            bool playerWins = (playerChoice - computerChoice + 3) % 3 == 1;
            bool playerTie = playerChoice == computerChoice;

            // Output the results.
            string results = "The computer wins!";
            results = playerChoice >= 0 && playerWins ? "You win!" : results;
            results = playerChoice >= 0 && playerTie ? "You tied!" : results;
            results = playerChoice < 0 ? "No winner. Invalid input." : results;

            Console.WriteLine($"You chose {playerString}.");
            Console.WriteLine($"The computer chose {computerString}.");
            Console.WriteLine(results);
        }
    }
}