using NUnit.Framework;

namespace Tests.Unit
{
    [TestFixture]
    public class BetterCalculatorTests
    {
        [Test]
        public void ShouldSumThreeNumbers()
        {
            var calculator = new BetterCalculator();
            var sum = calculator.Add(4)
                .Add(5)
                .Add(6)
                .Total();

            Assert.That(sum, Is.EqualTo(15));
        }

        [Test]
        public void ShouldPerformMultipleOperation()
        {
            var calculator = new BetterCalculator();
            var result = calculator.Add(4)
                .Multiply(5)
                .Divide(2)
                .Total();

            Assert.That(result, Is.EqualTo(10));
        }
    }
}