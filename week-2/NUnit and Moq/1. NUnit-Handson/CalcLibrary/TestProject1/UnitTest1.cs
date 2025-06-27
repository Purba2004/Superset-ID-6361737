using NUnit.Framework;
using CalcLibrary;
using System;

namespace TestProject1
{
    [TestFixture]
    public class SimpleCalculatorTests
    {
        private SimpleCalculator? calculator;

        [SetUp]
        public void Init()
        {
            calculator = new SimpleCalculator();
        }

        [TearDown]
        public void Cleanup()
        {
            calculator = null;
        }

        [Test]
        [TestCase(10, 5, 15)]
        [TestCase(0, 0, 0)]
        [TestCase(-2, -3, -5)]
        public void Addition_ShouldReturnCorrectResult(double a, double b, double expected)
        {
            double result = calculator!.Addition(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(10, 5, 5)]
        [TestCase(0, 0, 0)]
        [TestCase(-2, -3, 1)]
        public void Subtraction_ShouldReturnCorrectResult(double a, double b, double expected)
        {
            double result = calculator!.Subtraction(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(2, 3, 6)]
        [TestCase(0, 5, 0)]
        [TestCase(-2, -3, 6)]
        public void Multiplication_ShouldReturnCorrectResult(double a, double b, double expected)
        {
            double result = calculator!.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(10, 2, 5)]
        [TestCase(5, 2, 2.5)]
        public void Division_ShouldReturnCorrectResult(double a, double b, double expected)
        {
            double result = calculator!.Division(a, b);
            Assert.That(result, Is.EqualTo(expected).Within(0.0001));
        }

        [Test]
        public void Division_ByZero_ShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => calculator!.Division(10, 0));
        }

        [Test]
        public void AllClear_ShouldResetResultToZero()
        {
            calculator!.Addition(5, 5);
            calculator.AllClear();
            Assert.That(calculator.GetResult, Is.EqualTo(0));
        }
    }
}
