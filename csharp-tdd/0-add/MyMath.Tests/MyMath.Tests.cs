using NUnit.Framework;
using System;
using MyMath;

namespace MyMath.Tests
{
    public class OperationsTests
    {

        [Test]
        public void AddCorrectly()
        {
            int input = 1;

            int result = Operations.Add(input, input);

            Assert.AreEqual(2, result);
        }

        [Test]
        public void AddCorrectlyWithNegative()
        {
            int input = -1;

            int result = Operations.Add(input, input);

            Assert.AreEqual(-2, result);
        }

        [Test]
        public void AddCorrectlyWithZero()
        {
            int input = 0;

            int result = Operations.Add(input, input);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void AddCorrectlyWithMaxValue()
        {
            int input = int.MaxValue;

            int result = Operations.Add(input, input);

            Assert.AreEqual(-2, result);
        }
    }
}