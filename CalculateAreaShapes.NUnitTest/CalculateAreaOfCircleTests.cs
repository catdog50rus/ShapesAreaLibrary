using CalculateAreaShapes.Library;
using NUnit.Framework;
using System;

namespace CalculateAreaShapes.NUnitTest
{
    [TestFixture]
    public class CalculateAreaOfCircleTests
    {
        private const double PI = Math.PI;
        private readonly Circle _circle;

        public CalculateAreaOfCircleTests()
        {
            _circle = new Circle();
        }

        /// <summary>
        /// Получить площадь круга, результат площадь круга
        /// </summary>
        [TestCase(2.0)]
        public void CalculateAreaOfCircle_ShouldReturnArea(double radius)
        {
            double expArea = PI * Math.Pow(radius, 2);

            var result = _circle.GetAreaShape(radius);

            Assert.AreEqual(expArea, result, 0.1);
        }

        /// <summary>
        /// Получить площадь круга, результат ArgumentException
        /// </summary>
        [TestCase(-2)]
        [TestCase(0)]
        [TestCase(null)]
        [TestCase(2, 3)] //передаем два параметра вместо одного
        public void CalculateAreaOfCircle_ShouldReturnExcepation(double radius, double ex = 0)
        {
            double[] parameters;
            if (ex==0)
                parameters = new double[] { radius };
            else
                parameters = new double[] { radius, ex };
          

            Assert.Throws<ArgumentException>(() => _circle.GetAreaShape(parameters));
        }
    }
}