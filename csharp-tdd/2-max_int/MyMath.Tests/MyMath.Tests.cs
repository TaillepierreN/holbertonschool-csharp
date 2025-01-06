using NUnit.Framework;
using System.Collections.Generic;
using MyMath;
using System;

namespace MyMath.Tests
{
    public class OperationTests
    {
        [Test]
        public void Max_Positive_ReturnCorrectOutput()
        {
            List<int> input = new List<int> { 1, 5, 503, 14, 95 };

            int result = Operations.Max(input);

            Assert.AreEqual(503, result);
        }

        [Test]
        public void Max_Negative_ReturnCorrectOutput()
        {
            List<int> input = new List<int> { -1, -5, -503, -14, -95 };

            int result = Operations.Max(input);

            Assert.AreEqual(-1, result);
        }

        [Test]
        public void Max_Mixed_ReturnCorrectOutput()
        {
            List<int> input = new List<int> { -1, 5, -503, 14, -95 };

            int result = Operations.Max(input);

            Assert.AreEqual(14, result);
        }

        [Test]
        public void Max_Null_ReturnZero()
        {
            List<int> input = null;

            int result = Operations.Max(input);

            Assert.AreEqual(0, result);
        }

        [Test]
        public void Max_Empty_ReturnZero()
        {
            List<int> input = new List<int>();

            int result = Operations.Max(input);

            Assert.AreEqual(0, result);
        }
    }
}