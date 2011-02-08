
using NUnit.Framework;

namespace Tests.Calculators
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

        [Test]
        public void AddTwoNumbers()
        {
            calculator = new Calculator();

            Assert.That(calculator.Add(2, 4), Is.EqualTo(6));
        }
    }
}
