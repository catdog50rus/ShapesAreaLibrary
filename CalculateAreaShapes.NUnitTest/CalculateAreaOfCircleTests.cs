using CalculateAreaShapes.Library;
using NUnit.Framework;
using System;

namespace CalculateAreaShapes.NUnitTest
{
    [TestFixture]
    public class CalculateAreaOfCircleTests
    {
        private const double PI = Math.PI;
        private Circle _circle;

        /// <summary>
        /// Получить площадь круга, результат площадь круга
        /// </summary>
        [TestCase(2.0)]
        public void CalculateAreaOfCircle_ShouldReturnArea(double radius)
        {
            double expArea = PI * Math.Pow(radius, 2);
            _circle = new Circle(radius);

            var result = _circle.GetAreaShape();

            Assert.AreEqual(expArea, result);
        }

        /// <summary>
        /// Получить площадь круга, результат ArgumentException
        /// </summary>
        [TestCase(-2)]
        [TestCase(0)]
        [TestCase(null)]
        public void CalculateAreaOfCircle_ShouldReturnExcepation(double radius)
        {
            Assert.Throws<ArgumentException>(() => _circle = new Circle(radius));
        }
    }
}