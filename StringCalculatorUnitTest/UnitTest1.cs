using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StringCalculatorUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private StringCalculator calculator = new StringCalculator();

        [TestMethod]
        public void TestMethodEmpty()
        {
            Assert.AreEqual(0, calculator.add(""));
        }

        [TestMethod]
        public void TestMethodOneNumber()
        {
            Assert.AreEqual(1, calculator.add("1"));
        }

        [TestMethod]
        public void TestMethodTwoNumbers()
        {
            Assert.AreEqual(3, calculator.add("1,2"));
        }

        [TestMethod]
        public void TestMethodMultipleNumbers()
        {
            Assert.AreEqual(15, calculator.add("1,2,3,4,5"));
            
        }

        [TestMethod]
        public void TestMethodBreakLine()
        {
            Assert.AreEqual(6, calculator.add("1\n2,3"));
        }

        [TestMethod]
        public void TestMethodPlus1000()
        {
            Assert.AreEqual(2, calculator.add("2, 1001"));
        }

        [TestMethod]
        public void TestMethodDelimiter()
        {
            Assert.AreEqual(12, calculator.add("//*\n2*10"));
        }

        [TestMethod]
        public void TestMethodDelimiters()
        {
            Assert.AreEqual(12, calculator.add("//***\n2***10"));
        }

        [TestMethod]
        public void TestMultipleDelimiters()
        {
            Assert.AreEqual(6, calculator.add("//[*][%]\n1*2%3"));
        }

        [TestMethod]
        public void TestMultipleLongDelimiters()
        {
            Assert.AreEqual(12, calculator.add("//[***][%%%][$$]\n1***2%%%3$$6"));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception),
            "Negative numbers are not allowed")]
        public void TestMethodException()
        {
            Assert.AreEqual(-1, calculator.add("1,-2"));
        }

    }
}
