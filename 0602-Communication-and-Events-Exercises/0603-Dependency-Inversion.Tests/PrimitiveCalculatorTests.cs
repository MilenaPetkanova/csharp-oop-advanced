//namespace _0603_Dependency_Inversion.Tests
//{
    using NUnit.Framework;
    using P03_DependencyInversion;
    using System;

    [TestFixture]
    public class PrimitiveCalculatorTests
    {
        [Test]
        public void ChangeStrategyToDivision()
        {
            var defaultStrategy = new AdditionStrategy();
            var calculator = new PrimitiveCalculator(defaultStrategy);

            calculator.ChangeStrategy('/');

            Assert.That(calculator.PerformCalculation(10, 2).Equals(5)
                || !calculator.PerformCalculation(10, 2).Equals(12));
        }
    }
//}
