using CalculateAreaShapes.Library;
using NUnit.Framework;
using System;

namespace CalculateAreaShapes.NUnitTest
{
    [TestFixture]
    class CalculateAreaOfTriangleTests
    {
        private readonly Triangle _triangle;

        public CalculateAreaOfTriangleTests()
        {
            _triangle = new Triangle();
        }

        /// <summary>
        /// Получить площадь треугольника, результат площадь треугольника
        /// </summary>
        [TestCase(2, 3, 4)]
        [TestCase(3, 4, 5)] //Прямоугольный треугольник
        public void CalculateAreaOfTriangle_ShouldReturnArea(double a, double b, double c)
        {
            var p = (a+b+c)/2;
            var expArea = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            double[] parameters = { a, b, c };
            
            var result = _triangle.GetAreaShape(parameters);

            Assert.AreEqual(expArea, result);
        }

        /// <summary>
        /// Получить площадь треугольника, результат ArgumentException
        /// </summary>
        [TestCase(0, 3, 4)]
        [TestCase(2, -3, 4)]
        [TestCase(null, 3, 4)] 
        [TestCase(2)] //Указано меньше сторон
        public void CalculateAreaOfTriangle_ShouldReturnExcepation(double a, double b=0, double c=0)
        {
            double[] parameters;
            if (b == 0 && c == 0)//Проверяем с одним аргументом(case4)
                parameters = new double[] { a };
            else
                parameters = new double[] { a, b, c };

            Assert.Throws<ArgumentException>(() => _triangle.GetAreaShape(parameters));
        }
    }
}
