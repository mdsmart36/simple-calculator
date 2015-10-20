using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;
using System.Collections.Generic;

namespace UnitTestCalculator
{
    [TestClass]
    public class UnitTestStack
    {
            

        [TestMethod]
        public void TestStackGetAndSetAnswer()
        {
            //Stack stack = new Stack();
            Stack.PutAnswerOnStack(1);
            Assert.AreEqual(1, Stack.GetAnswerFromStack());
        }

        [TestMethod]
        public void TestStackGetAndSetExpression()
        {
            //Stack stack = new Stack();
            Stack.PutExpressionOnStack("8 * 1");
            Assert.AreEqual("8 * 1", Stack.GetExpressionFromStack());
        }

        // test AddConstant
        [TestMethod]
        public void TestAddConstantNotAlreadyAdded()
        {
            bool success = Stack.AddConstant("x", 3);
            Assert.AreEqual(true, success);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestAddConstantAlreadyAdded()
        {
            Stack.AddConstant("x", 3);
            Stack.AddConstant("x", 4);
            //Assert.AreEqual(false, success);
        }

        // test ConstantIsAssigned
        [TestMethod]
        public void TestConstantPreviouslyAssigned()
        {
            string key = "x";
            Stack.AddConstant(key, 3);
            Assert.IsTrue(Stack.ConstantIsAssigned(key));
        }

        // test ReturnConstantValue
        [TestMethod]
        public void TestReturnedConstantValue()
        {
            string key = "x";
            int value = 3;
            Stack.AddConstant(key, value);
            Assert.AreEqual(value, Stack.ReturnConstantValue(key));
            
        }

        [ExpectedException(typeof(KeyNotFoundException))]
        [TestMethod]
        public void TestReturnValueOfConstantNotAssigned()
        {
            string key = "x";
            int value = 3;
            Stack.AddConstant(key, value);
            Assert.AreEqual(value, Stack.ReturnConstantValue("y"));
        }
        
    }
}
