using System;
using System.IO;
using NUnit.Framework;
using RockPaperScissors;

namespace tests
{
    public class ProgramTest
    {
        private string[] GetOutputLines(string input, string seed)
        {
            // Create artifial input and output.
            StringReader reader = new StringReader($"{input}\n");
            StringWriter writer = new StringWriter();

            // Redirect input and output.
            TextWriter standardOutput = Console.Out;
            Console.SetIn(reader);
            Console.SetOut(writer);

            // Execute main program.
            if (seed == null)
                Program.Main(new string[] { });
            else
                Program.Main(new string[] { seed });
            Console.SetOut(standardOutput);
            Console.Write(writer.ToString());

            // Get the output lines.
            string[] lines = writer.ToString().Split('\n');
            return lines;
        }

        [Test]
        public void TestPrompt()
        {
            // Get prompt line.
            string[] lines = GetOutputLines("", null);
            string promptLine = lines.Length >= 1 ? lines[0] : "";

            // Check that prompt is correctly output.
            Assert.AreEqual("Rock, paper, or scissors?", promptLine);
        }

        [TestCase("rock", true)]
        [TestCase("paper", true)]
        [TestCase("scissors", true)]
        [TestCase("RoCK", true)]
        [TestCase("paPer", true)]
        [TestCase("SCISSORS", true)]
        [TestCase("lint", false)]
        [TestCase("carDBoard", false)]
        [TestCase("Bowl", false)]
        public void TestValidInput(string input, bool isValid)
        {
            // Get result line.
            string[] lines = GetOutputLines(input, null);
            string resultLine = lines.Length >= 4 ? lines[3] : "";

            // Check that invalid statement is printed when necessary.
            if (isValid)
                Assert.AreNotEqual("No winner. Invalid input.", resultLine);
            else
                Assert.AreEqual("No winner. Invalid input.", resultLine);
        }

        [TestCase("rock")]
        [TestCase("paper")]
        [TestCase("scissors")]
        [TestCase("RoCK")]
        [TestCase("paPer")]
        [TestCase("SCISSORS")]
        [TestCase("lint")]
        [TestCase("carDBoard")]
        [TestCase("Bowl")]
        public void TestPlayerLine(string input)
        {
            // Get player output line.
            string[] lines = GetOutputLines(input, null);
            string playerChoiceLine = lines.Length >= 2 ? lines[1] : "";

            // Check that the player output is as expected.
            Assert.AreEqual(
                $"You chose {input.ToLower()}.", playerChoiceLine
            );
        }

        [TestCase("1", "rock")]
        [TestCase("2", "scissors")]
        [TestCase("3", "rock")]
        [TestCase("4", "scissors")]
        [TestCase("5", "paper")]
        [TestCase("16", "rock")]
        [TestCase("70", "rock")]
        public void TestRandomGeneration(string seed, string choice)
        {
            // Get computer output line.
            string[] lines = GetOutputLines("", seed);
            string computerChoiceLine = lines.Length >= 3 ? lines[2] : "";

            // Check that the computer output is as expected.
            Assert.AreEqual(
                $"The computer chose {choice}.", computerChoiceLine
            );
        }

        [Test]
        public void TestGameRules()
        {
            // Specify number of tests and user inputs.
            const int NUMBER_TESTS = 10000;
            string[] choices = new string[]
            {
                "rock",
                "paper",
                "scissors"
            };

            // Check that game rules work properly for each test.
            for (int i = 0; i < NUMBER_TESTS; i++)
            {
                // Simulate results of game.
                var rng = new Random(i);
                int playerChoice = i % 3;
                int computerChoice = rng.Next(3);

                // Run program.
                string seed = $"{i}";
                string choice = choices[playerChoice];
                string[] lines = GetOutputLines(choice, seed);
                string resultLine = lines.Length >= 4 ? lines[3] : "";

                // Check for correct results of program.
                // Recall 0 = ROCK, 1 = PAPER, 2 = SCISSORS
                if (playerChoice == computerChoice)
                    Assert.AreEqual("You tied!", resultLine);
                else if (playerChoice == 0)
                {
                    if (computerChoice == 1)
                        Assert.AreEqual("The computer wins!", resultLine);
                    if (computerChoice == 2)
                        Assert.AreEqual("You win!", resultLine);
                }
                else if (playerChoice == 1)
                {
                    if (computerChoice == 0)
                        Assert.AreEqual("You win!", resultLine);
                    if (computerChoice == 2)
                        Assert.AreEqual("The computer wins!", resultLine);
                }
                else if (playerChoice == 2)
                {
                    if (computerChoice == 0)
                        Assert.AreEqual("The computer wins!", resultLine);
                    if (computerChoice == 1)
                        Assert.AreEqual("You win!", resultLine);
                }
            }
        }
    }
}