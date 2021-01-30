using CalculateAreaShapes.Library;
using NUnit.Framework;
using System;

namespace CalculateAreaShapes.NUnitTest
{
    [TestFixture]
    class IsRightTriangleTests
    {
        private readonly Triangle _triangle;

        public IsRightTriangleTests()
        {
            _triangle = new Triangle();
        }

        /// <summary>
        /// Проверить,является ли треугольник прямоугольным, результат TRUE
        /// </summary>
        [TestCase(3, 4, 5)] //Прямоугольный треугольник
        public void IsRightfTriangle_ShouldReturnTrue(double a, double b, double c)
        {
            double[] parameters = { a, b, c };

            var result = _triangle.IsRightTriangle(parameters);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Проверить,является ли треугольник прямоугольным, результат False
        /// </summary>
        [TestCase(2, 3, 4)] //Не прямоугольный треугольник
        public void IsRightfTriangle_ShouldReturnFalse(double a, double b, double c)
        {
            double[] parameters = { a, b, c };

            var result = _triangle.IsRightTriangle(parameters);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// Проверить,является ли треугольник прямоугольным, результат Exception
        /// </summary>
        [TestCase(0, 3, 4)]
        [TestCase(2, -3, 4)]
        [TestCase(null, 3, 4)]
        [TestCase(2)] //Указано меньше сторон
        public void IsRightTriangleTriangle_ShouldReturnExcepation(double a, double b = 0, double c = 0)
        {
            double[] parameters;
            if (b == 0 && c == 0)//Проверяем с одним аргументом(case4)
                parameters = new double[] { a };
            else
                parameters = new double[] { a, b, c };

            Assert.Throws<ArgumentException>(() => _triangle.IsRightTriangle(parameters));
        }
    }
}
