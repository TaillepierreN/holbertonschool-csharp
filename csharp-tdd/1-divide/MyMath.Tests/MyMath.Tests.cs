using NUnit.Framework;
using MyMath;
using System;

namespace MyMath.Tests
{
    public class MatrixTests
    {
        [Test]
        public void Divide_ValidInput_ReturnCorrectOutput()
        {
            int[,] inputs = new int[,] { { 2, 4}, { 6, 8}};
            int num = 2;
            int[,] expectedOutput = new int[,] {{1,2},{3,4}};

            int[,] result = Matrix.Divide(inputs, num);

            Assert.AreEqual(expectedOutput, result);
        }

        [Test]
        public void Divide_InputZero_ReturnNull()
        {
            int[,] inputs = new int[,] { { 2, 4}, { 6, 8}};
            int num = 0;

            int[,] result = Matrix.Divide(inputs, num);

            Assert.IsNull(result);
        }

        [Test]
        public void Divide_InputNull_ReturnNull()
        {
            int[,] result = Matrix.Divide(null, 2);

            Assert.IsNull(result);
        }

        [Test]
        public void Divide_InputNegative_ReturnCorrectOutput()
        {
            int[,] inputs = new int[,] { { 2, 4}, { 6, 8}};
            int num = -2;
            int[,] expectedOutput = new int[,] {{-1,-2},{-3,-4}};

            int[,] result = Matrix.Divide(inputs, num);

            Assert.AreEqual(expectedOutput, result);
        }
    }
}