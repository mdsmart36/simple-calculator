using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;

namespace UnitTestCalculator
{
    [TestClass]
    public class UnitTestParse
    {
        [TestMethod]
        public void ReturnValidTerms()
        {
            string input = "8 * 3";
            Parse myText = new Parse(input);
            Assert.AreEqual(8, myText.GetFirstValue());
            Assert.AreEqual(3, myText.GetSecondValue());            
        }

        [TestMethod]
        public void ReturnValidOperation()
        {
            string input = "8 + 3";
            Parse myText = new Parse(input);
            Assert.AreEqual("+", myText.GetOperation());

            input = "8 - 1";
            myText = new Parse(input);
            Assert.AreEqual("-", myText.GetOperation());

            input = "8 * 1";
            myText = new Parse(input);
            Assert.AreEqual("*", myText.GetOperation());

            input = "8 / 1";
            myText = new Parse(input);
            Assert.AreEqual("/", myText.GetOperation());

            input = "8 % 1";
            myText = new Parse(input);
            Assert.AreEqual("%", myText.GetOperation());
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void TestInputForBadFirstValue()
        {
            string input = "* 8 3";
            Parse myText = new Parse(input);
            myText.GetFirstValue();
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void TestInputForBadSecondValue()
        {
            string input = "1 8 +";
            Parse myText = new Parse(input);
            myText.GetSecondValue();
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void TestForInvalidOperations()
        {
            string input = "2 & 2";
            Parse myText = new Parse(input);
            myText.GetOperation();
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void TestForStrangeInput()
        {
            string input = "MattSmart Nashville Software";
            Parse myText = new Parse(input);
            myText.GetFirstValue();
        }

        [TestMethod]
        public void TestForExtraSpacesAroundOperation()
        {
            string input = "   8    *       3   ";
            Parse myText = new Parse(input);
            Assert.AreEqual(8, myText.GetFirstValue());
            Assert.AreEqual("*", myText.GetOperation());
            Assert.AreEqual(3, myText.GetSecondValue());
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void TestForExtraSpacesAndInvalidInput()
        {
            string input = "   x    (  4 ";
            Parse myText = new Parse(input);
            myText.GetFirstValue();
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void TestForEmptyInput()
        {
            string input = "";
            Parse myText = new Parse(input);
            myText.GetFirstValue();
        }

        [ExpectedException(typeof(FormatException))]
        [TestMethod]
        public void TestForDecimals()
        {
            string input = "2.3 * 5";
            Parse myText = new Parse(input);
            myText.GetFirstValue();
        }

        [TestMethod]
        public void TestForKeywordLast()
        {
            string input = " last";
            Parse myText = new Parse(input);
            Assert.IsTrue(myText.IsKeywordEntered());
        }

        [TestMethod]
        public void TestForKeywordLastUppercase()
        {
            string input = " LAST";
            Parse myText = new Parse(input);
            Assert.IsTrue(myText.IsKeywordEntered());
        }

        [TestMethod]
        public void TestForKeywordLastQ()
        {
            string input = " lastq";
            Parse myText = new Parse(input);
            Assert.IsTrue(myText.IsKeywordEntered());
        }

        [TestMethod]
        public void TestForKeywordLastQUppercase()
        {
            string input = "    LASTQ    ";
            Parse myText = new Parse(input);
            Assert.IsTrue(myText.IsKeywordEntered());
        }

        [TestMethod]
        public void TestParseGoodInputAndPutOnStack()
        {
            string input = "8 * 3";
            int expectedAnswer = 24;
            Parse myText = new Parse(input);
            Evaluate evaluator = new Evaluate(myText.GetFirstValue(), myText.GetOperation(), myText.GetSecondValue());
            int answer = evaluator.ReturnAnswer();
            Assert.AreEqual(expectedAnswer, answer);
            //Stack stack = new Stack();
            Stack.PutAnswerOnStack(answer);
            Assert.AreEqual(answer, Stack.GetAnswerFromStack());
        }

        [TestMethod]
        public void TestParsegoodInputAndPutExpressionOnStack()
        {
            string input = "8 * 3";
            int expectedAnswer = 24;
            Parse myText = new Parse(input);
            Evaluate evaluator = new Evaluate(myText.GetFirstValue(), myText.GetOperation(), myText.GetSecondValue());
            int answer = evaluator.ReturnAnswer();
            Assert.AreEqual(expectedAnswer, answer);
            //Stack stack = new Stack();
            Stack.PutAnswerOnStack(answer);
            Stack.PutExpressionOnStack(input);
            Assert.AreEqual(answer, Stack.GetAnswerFromStack());
            Assert.AreEqual(input, Stack.GetExpressionFromStack());
        }

        [TestMethod]
        public void TestReturnLastAnswer()
        {
            string input = "8 * 3";
            int expectedAnswer = 24;
            Parse myText = new Parse(input);
            Evaluate evaluator = new Evaluate(myText.GetFirstValue(), myText.GetOperation(), myText.GetSecondValue());
            int answer = evaluator.ReturnAnswer();
            //Stack stack = new Stack();
            Stack.PutAnswerOnStack(answer);
            Stack.PutExpressionOnStack(input);

            input = "last";
            myText.SetTextToParse(input);

            if (myText.IsKeywordEntered())
            {
                if (myText.GetKeyword() == "last")
                {
                    answer = Stack.GetAnswerFromStack();
                }
            }

            Assert.AreEqual(expectedAnswer, answer);
            
        }

        [TestMethod]
        public void TestReturnLastExpression()
        {
             string input = "8 * 3";
            //int expectedAnswer = 24;
            
            Parse myText = new Parse();
            myText.SetTextToParse(input);
            Evaluate evaluator = new Evaluate(myText.GetFirstValue(), myText.GetOperation(), myText.GetSecondValue());
            int answer = evaluator.ReturnAnswer();
            //Stack stack = new Stack();
            Stack.PutAnswerOnStack(answer);
            Stack.PutExpressionOnStack(input);

            
            myText.SetTextToParse("lastq");
            string answerString = "";

            if (myText.IsKeywordEntered())
            {
                if (myText.GetKeyword() == "lastq")
                {
                    answerString = Stack.GetExpressionFromStack();
                }
            }

            Assert.AreEqual(input, answerString);
            
        }
    }
}
