﻿
using NUnit.Framework;

namespace Tests.Unit
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [Test]
        public void MultiplyTwoNumbers()
        {
            calculator = new Calculator();
            Assert.That(calculator.Multiply(2, 4), Is.EqualTo(8));
        }
    }
}
