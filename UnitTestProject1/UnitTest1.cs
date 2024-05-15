using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestCalculateLn_TermCount()
        {
            // Arrange
            double x = 1.5;
            double epsilon = 0.0001;
            int terms;

            // Act
            double result = TaylorSeriesApp.Program.CalculateLn(x, epsilon, out terms);

            // Assert
            Assert.IsTrue(terms > 0, "The number of terms should be greater than 0.");
        }

        [TestMethod]
        public void TestCalculateNextLnTerm()
        {
            // Arrange
            double currentTerm = 0.5;
            double x = 1.5;
            int n = 1;

            // Act
            double nextTerm = TaylorSeriesApp.Program.CalculateNextLnTerm(currentTerm, x, n);

            // Assert
            double expectedNextTerm = -currentTerm * (x - 1) / (n + 1);
            Assert.AreEqual(expectedNextTerm, nextTerm, 0.0001, "The next term calculation is incorrect.");
        }
    }
}