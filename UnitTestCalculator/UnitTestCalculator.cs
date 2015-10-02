using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;
using System.Collections.Generic;

namespace UnitTestSimpleCalculator
{
    [TestClass]
    public class UnitTestCalculator
    {
        [TestMethod]
        public void TestCounter()
        {
            Calculator myCalc = new Calculator();
            Assert.AreEqual(0, myCalc.GetCounter());
        }

        [TestMethod]
        public void TestSetInputs()
        {
            Calculator myCalc = new Calculator();
            myCalc.Inputs = new List<string>();
            myCalc.Inputs.Add("3+1");
            Assert.AreEqual(true, myCalc.Inputs.Contains("3+1"));
        }

        [TestMethod]
        public void TestSetConstants()
        {
            Calculator myCalc = new Calculator();
            myCalc.Constants = new Dictionary<string, int>();
            myCalc.Constants.Add("x", 3);
            Assert.AreEqual(3, myCalc.Constants["x"]);
        }

        [TestMethod]
        public void TestPrintStringString()
        {
            Calculator myCalc = new Calculator();
            string message = "this is the message";
            string answer = "3";
            Assert.AreEqual("this is the message = 3", myCalc.Print(message, answer));
        }

        [TestMethod]
        public void TestPrintStringInteger()
        {
            Calculator myCalc = new Calculator();
            string message = "this is the message";
            int answer = 3;
            Assert.AreEqual("this is the message = 3", myCalc.Print(message, answer));
        }

        [TestMethod]
        public void TestGetInput()
        {
            
        }

        [TestMethod]
        public void TestValidateInputAdd()
        {
            Calculator myCalc = new Calculator();
            string input = "9 + 4";
            Assert.AreEqual(Calculator.Action.ADD, myCalc.ValidateInput(input));
        }

        [TestMethod]
        public void TestValidateInputSubtract()
        {
            Calculator myCalc = new Calculator();
            string input = "9 - 4";
            Assert.AreEqual(Calculator.Action.SUBTRACT, myCalc.ValidateInput(input));
        }

        [TestMethod]
        public void TestValidateInputMultiply()
        {
            Calculator myCalc = new Calculator();
            string input = "9 * 4";
            Assert.AreEqual(Calculator.Action.MULTIPLY, myCalc.ValidateInput(input));
        }

        [TestMethod]
        public void TestValidateInputDivide()
        {
            Calculator myCalc = new Calculator();
            string input = "9 / 4";
            Assert.AreEqual(Calculator.Action.DIVIDE, myCalc.ValidateInput(input));
        }

        [TestMethod]
        public void TestValidateInputModulus()
        {
            Calculator myCalc = new Calculator();
            string input = "9 % 4";
            Assert.AreEqual(Calculator.Action.MODULUS, myCalc.ValidateInput(input));
        }

        [TestMethod]
        public void TestValidateInputExit()
        {
            Calculator myCalc = new Calculator();
            string input = "   exit ";
            Assert.AreEqual(Calculator.Action.EXIT, myCalc.ValidateInput(input));
        }

        [TestMethod]
        public void TestValidateInputBye()
        {
            Calculator myCalc = new Calculator();
            string input = "quit ";
            Assert.AreEqual(Calculator.Action.EXIT, myCalc.ValidateInput(input));
        }

        [TestMethod]
        public void TestValidateInputLASTQ()
        {
            Calculator myCalc = new Calculator();
            string input = " lastq";
            Assert.AreEqual(Calculator.Action.LASTQ, myCalc.ValidateInput(input));
        }

        [TestMethod]
        public void TestValidateInputLAST()
        {
            Calculator myCalc = new Calculator();
            string input = " last ";
            Assert.AreEqual(Calculator.Action.LAST, myCalc.ValidateInput(input));
        }
        
        [TestMethod]
        public void TestValidateInputInvalidInput()
        {
            Calculator myCalc = new Calculator();
            string input = " my name";
            Assert.AreEqual(Calculator.Action.INVALID, myCalc.ValidateInput(input));
        }

        [TestMethod]
        public void TestValidateInputConstantAssign()
        {
            Calculator myCalc = new Calculator();
            string input = " j =   44";
            Assert.AreEqual(Calculator.Action.CONSTANT_ASSIGN, myCalc.ValidateInput(input));
        }

        [TestMethod]
        public void TestValidateInputConstantLookup()
        {
            Calculator myCalc = new Calculator();
            myCalc.Constants.Add("d", 7);
            string input = " d ";
            Assert.AreEqual(Calculator.Action.CONSTANT_LOOKUP, myCalc.ValidateInput(input));
        }

        [TestMethod]
        public void TestValidateInputConstantError()
        {
            Calculator myCalc = new Calculator();
            myCalc.Constants.Add("d", 7);
            string input = "d = 3";
            Assert.AreEqual(Calculator.Action.CONSTANT_ERROR, myCalc.ValidateInput(input));
        }

        [TestMethod]
        public void TestValidateInputConstantNotAssigned()
        {
            Calculator myCalc = new Calculator();
            string input = "d";
            Assert.AreEqual(Calculator.Action.CONSTANT_NOTASSIGNED, myCalc.ValidateInput(input));
        }
        
    }
}
