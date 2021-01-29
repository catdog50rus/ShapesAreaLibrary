using CalculateAreaShapes.Labrary;
using NUnit.Framework;
using System;

namespace CalculateAreaShapes.NUnitTest
{
    [TestFixture]
    class IsRightTriangleTests
    {
        /// <summary>
        /// Проверить,является ли треугольник прямоугольным, результат TRUE
        /// </summary>
        /// <param name="type"></param>
        /// <param name="radius"></param>
        /// <param name="expArea"></param>
        [TestCase(ShapeType.Triangle, 3, 4, 5)] //Прямоугольный треугольник
        public void IsRightfTriangle_ShouldReturnTrue(ShapeType type, double a, double b, double c)
        {
            double[] parameters = { a, b, c };

            var shapes = new AreaShapes(type);

            var result = shapes.IsRightTriangle(parameters);

            Assert.IsTrue(result);
        }

        /// <summary>
        /// Проверить,является ли треугольник прямоугольным, результат False
        /// </summary>
        /// <param name="type"></param>
        /// <param name="radius"></param>
        /// <param name="expArea"></param>
        [TestCase(ShapeType.Triangle, 2, 3, 4)] //Прямоугольный треугольник
        public void IsRightfTriangle_ShouldReturnFalse(ShapeType type, double a, double b, double c)
        {
            double[] parameters = { a, b, c };

            var shapes = new AreaShapes(type);

            var result = shapes.IsRightTriangle(parameters);

            Assert.IsFalse(result);
        }

        /// <summary>
        /// Проверить,является ли треугольник прямоугольным, результат Exception
        /// </summary>
        /// <param name="type"></param>
        /// <param name="radius"></param>
        /// <param name="expArea"></param>
        [TestCase(ShapeType.Triangle, 0, 3, 4)]
        [TestCase(ShapeType.Triangle, 2, -3, 4)]
        [TestCase(ShapeType.Triangle, null, 3, 4)]
        [TestCase(ShapeType.Triangle, 2)] //Указано меньше сторон
        public void IsRightTriangleTriangle_ShouldReturnExcepation(ShapeType type, double a, double b = 0, double c = 0)
        {
            double[] parameters;
            if (b == 0 && c == 0)//Проверяем с одним аргументом(case4)
                parameters = new double[] { a };
            else
                parameters = new double[] { a, b, c };

            var shapes = new AreaShapes(type);

            Assert.Throws<ArgumentException>(() => shapes.IsRightTriangle(parameters));
        }
    }
}
