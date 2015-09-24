﻿using System;
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
            myCalc.Constants = new Dictionary<char, int>();
            myCalc.Constants.Add('x', 3);
            Assert.AreEqual(3, myCalc.Constants['x']);
        }
    }
}
