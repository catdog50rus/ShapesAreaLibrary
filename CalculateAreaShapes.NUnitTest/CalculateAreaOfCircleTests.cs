using CalculateAreaShapes.Labrary;
using NUnit.Framework;
using System;

namespace CalculateAreaShapes.NUnitTest
{
    [TestFixture]
    public class CalculateAreaOfCircleTests
    {
        private const double PI = Math.PI;

        /// <summary>
        /// Получить площадь круга, результат площадь круга
        /// </summary>
        /// <param name="type"></param>
        /// <param name="radius"></param>
        /// <param name="expArea"></param>
        [TestCase(ShapeType.Circle, 2.0)]
        public void CalculateAreaOfCircle_ShouldReturnArea(ShapeType type, double radius)
        {
            double expArea = PI * Math.Pow(radius, 2);

            var shapes = new AreaShapes(type);

            var result = shapes.GetAreaShape(radius);

            Assert.AreEqual(expArea, result, 0.1);
        }

        /// <summary>
        /// Получить площадь круга, результат ArgumentException
        /// </summary>
        /// <param name="type"></param>
        /// <param name="radius"></param>
        /// <param name="expArea"></param>
        [TestCase(ShapeType.Circle, -2)]
        [TestCase(ShapeType.Circle, 0)]
        [TestCase(ShapeType.Circle, null)]
        [TestCase(ShapeType.Circle, 2, 3)] //передаем два параметра вместо одного
        public void CalculateAreaOfCircle_ShouldReturnExcepation(ShapeType type, double radius, double ex = 0)
        {
            double[] parameters;
            if (ex==0)
                parameters = new double[] { radius };
            else
                parameters = new double[] { radius, ex };
            
            var shapes = new AreaShapes(type);

            Assert.Throws<ArgumentException>(() => shapes.GetAreaShape(parameters));
        }
    }
}