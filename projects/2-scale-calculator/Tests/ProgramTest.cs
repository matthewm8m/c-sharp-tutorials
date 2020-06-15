using System;
using System.IO;
using NUnit.Framework;
using ScaleCalculator;

namespace tests
{
    public class ProgramTest
    {
        private string[] GetOutputLines(string input1, string input2)
        {
            // Create artifial input and output.
            StringReader reader = new StringReader($"{input1}\n{input2}\n");
            StringWriter writer = new StringWriter();

            // Redirect input and output.
            Console.SetIn(reader);
            Console.SetOut(writer);

            // Execute main program.
            Program.Main(new string[] { });

            // Get the output lines.
            string[] lines = writer.ToString().Split('\n');
            return lines;
        }

        [Test]
        public void TestPrompts()
        {
            // Get prompt lines.
            string[] lines = GetOutputLines(" ", " ");
            string promptLine1 = lines.Length >= 1 ? lines[0] : "";
            string promptLine2 = lines.Length >= 2 ? lines[1] : "";

            // Check that prompt is correctly output.
            Assert.AreEqual(
                "Would you like to calculate a major or minor scale?",
                promptLine1
            );
            Assert.AreEqual(
                "Enter the starting frequency (in Hz):",
                promptLine2
            );
        }

        [TestCase("major", "440", true)]
        [TestCase("minor", "440", true)]
        [TestCase("MaJoR", "660.5", true)]
        [TestCase("mInOr", "660.5", true)]
        [TestCase("scale", "440", false)]
        [TestCase("major", "banana", false)]
        [TestCase("SCALE", "cherry", false)]
        public void TestValidInput(string input1, string input2, bool isValid)
        {
            // Get result line.
            string[] lines = GetOutputLines(input1, input2);
            string resultLine = lines.Length > 1 ? lines[lines.Length - 2] : "";

            // Check that invalid statement is printed when necessary.
            if (isValid)
                Assert.AreNotEqual("Invalid input.", resultLine);
            else
                Assert.AreEqual("Invalid input.", resultLine);
        }

        [TestCase(440.0)]
        [TestCase(880.0)]
        [TestCase(55.0)]
        [TestCase(277.18)]
        [TestCase(622.25)]
        public void TestMajorScale(double frequency)
        {
            // Get result lines.
            string[] lines = GetOutputLines("major", frequency.ToString());
            Assert.IsTrue(lines.Length > 8);

            // Check that the frequency output is as expected.
            Assert.AreEqual(
                $"Note 1: {frequency * Math.Pow(2d, 0 / 12d):F2}",
                lines[lines.Length - 9]
            );
            Assert.AreEqual(
                $"Note 2: {frequency * Math.Pow(2d, 2 / 12d):F2}",
                lines[lines.Length - 8]
            );
            Assert.AreEqual(
                $"Note 3: {frequency * Math.Pow(2d, 4 / 12d):F2}",
                lines[lines.Length - 7]
            );
            Assert.AreEqual(
                $"Note 4: {frequency * Math.Pow(2d, 5 / 12d):F2}",
                lines[lines.Length - 6]
            );
            Assert.AreEqual(
                $"Note 5: {frequency * Math.Pow(2d, 7 / 12d):F2}",
                lines[lines.Length - 5]
            );
            Assert.AreEqual(
                $"Note 6: {frequency * Math.Pow(2d, 9 / 12d):F2}",
                lines[lines.Length - 4]
            );
            Assert.AreEqual(
                $"Note 7: {frequency * Math.Pow(2d, 11 / 12d):F2}",
                lines[lines.Length - 3]
            );
            Assert.AreEqual(
                $"Note 8: {frequency * Math.Pow(2d, 12 / 12d):F2}",
                lines[lines.Length - 2]
            );
        }

        [TestCase(440.0)]
        [TestCase(880.0)]
        [TestCase(55.0)]
        [TestCase(277.18)]
        [TestCase(622.25)]
        public void TestMinorScale(double frequency)
        {
            // Get result lines.
            string[] lines = GetOutputLines("minor", frequency.ToString());
            Assert.IsTrue(lines.Length > 8);

            // Check that the frequency output is as expected.
            Assert.AreEqual(
                $"Note 1: {frequency * Math.Pow(2d, 0 / 12d):F2}",
                lines[lines.Length - 9]
            );
            Assert.AreEqual(
                $"Note 2: {frequency * Math.Pow(2d, 2 / 12d):F2}",
                lines[lines.Length - 8]
            );
            Assert.AreEqual(
                $"Note 3: {frequency * Math.Pow(2d, 3 / 12d):F2}",
                lines[lines.Length - 7]
            );
            Assert.AreEqual(
                $"Note 4: {frequency * Math.Pow(2d, 5 / 12d):F2}",
                lines[lines.Length - 6]
            );
            Assert.AreEqual(
                $"Note 5: {frequency * Math.Pow(2d, 7 / 12d):F2}",
                lines[lines.Length - 5]
            );
            Assert.AreEqual(
                $"Note 6: {frequency * Math.Pow(2d, 8 / 12d):F2}",
                lines[lines.Length - 4]
            );
            Assert.AreEqual(
                $"Note 7: {frequency * Math.Pow(2d, 10 / 12d):F2}",
                lines[lines.Length - 3]
            );
            Assert.AreEqual(
                $"Note 8: {frequency * Math.Pow(2d, 12 / 12d):F2}",
                lines[lines.Length - 2]
            );
        }
    }
}