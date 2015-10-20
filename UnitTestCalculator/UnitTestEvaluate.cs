using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;

namespace UnitTestCalculator
{
    [TestClass]
    public class UnitTestEvaluate
    {
        [TestMethod]
        public void EvaluateGoodInputAddition()
        {
            string input = "8 + 2";
            int expectedAnswer = 10;
            
            Parse parser = new Parse(input);
            int val1 = parser.GetFirstValue();
            int val2 = parser.GetSecondValue();
            string operation = parser.GetOperation();

            Evaluate evaluator = new Evaluate(val1, operation, val2);
            int answer = evaluator.ReturnAnswer();
            Assert.AreEqual(expectedAnswer, answer);
        }

        [TestMethod]
        public void EvaluateGoodInputSubtraction()
        {
            string input = "8 - 2";
            int expectedAnswer = 6;
            

            Parse parser = new Parse(input);
            int val1 = parser.GetFirstValue();
            int val2 = parser.GetSecondValue();
            string operation = parser.GetOperation();

            Evaluate evaluator = new Evaluate(val1, operation, val2);
            int answer = evaluator.ReturnAnswer();
            Assert.AreEqual(expectedAnswer, answer);
        }

        [TestMethod]
        public void EvaluateGoodInputMultiplication()
        {
            string input = "8 * 2";
            int expectedAnswer = 16;
            

            Parse parser = new Parse(input);
            int val1 = parser.GetFirstValue();
            int val2 = parser.GetSecondValue();
            string operation = parser.GetOperation();

            Evaluate evaluator = new Evaluate(val1, operation, val2);
            int answer = evaluator.ReturnAnswer();
            Assert.AreEqual(expectedAnswer, answer);
        }

        [TestMethod]
        public void EvaluateGoodInputDivision()
        {
            string input = "8 / 2";
            int expectedAnswer = 4;
            
            Parse parser = new Parse(input);
            int val1 = parser.GetFirstValue();
            int val2 = parser.GetSecondValue();
            string operation = parser.GetOperation();

            Evaluate evaluator = new Evaluate(val1, operation, val2);
            int answer = evaluator.ReturnAnswer();
            Assert.AreEqual(expectedAnswer, answer);
        }

        [TestMethod]
        public void EvaluateGoodInputModulus()
        {
            string input = "8 % 3";
            int expectedAnswer = 2;
            

            Parse parser = new Parse(input);
            int val1 = parser.GetFirstValue();
            int val2 = parser.GetSecondValue();
            string operation = parser.GetOperation();

            Evaluate evaluator = new Evaluate(val1, operation, val2);
            int answer = evaluator.ReturnAnswer();
            Assert.AreEqual(expectedAnswer, answer);
        }

        [TestMethod]
        public void EvaluateGoodInputModulusWithExtraSpaces()
        {
            string input = "  8    %  3             ";
            int expectedAnswer = 2;
            

            Parse parser = new Parse(input);
            int val1 = parser.GetFirstValue();
            int val2 = parser.GetSecondValue();
            string operation = parser.GetOperation();

            Evaluate evaluator = new Evaluate(val1, operation, val2);
            int answer = evaluator.ReturnAnswer();
            Assert.AreEqual(expectedAnswer, answer);
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void EvaluateBadInputAddition()
        {
            // this test may not be needed because the Parse class handles all bad input
            string input = "+ 8 3";
            int expectedAnswer = 11;

            Parse parser = new Parse(input);
            int val1 = parser.GetFirstValue();
            int val2 = parser.GetSecondValue();
            string operation = parser.GetOperation();

            Evaluate evaluator = new Evaluate(val1, operation, val2);
            int answer = evaluator.ReturnAnswer();
            Assert.AreEqual(expectedAnswer, answer);
        }
    }
}
