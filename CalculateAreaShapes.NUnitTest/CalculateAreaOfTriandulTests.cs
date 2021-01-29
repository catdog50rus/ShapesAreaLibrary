using CalculateAreaShapes.Labrary;
using NUnit.Framework;
using System;

namespace CalculateAreaShapes.NUnitTest
{
    [TestFixture]
    class CalculateAreaOfTriandulTests
    {
        /// <summary>
        /// Получить площадь треугольника, результат площадь треугольника
        /// </summary>
        /// <param name="type"></param>
        /// <param name="radius"></param>
        /// <param name="expArea"></param>
        [TestCase(ShapeType.Triangle, 2, 3, 4)]
        public void CalculateAreaOfTriangle_ShouldReturnArea(ShapeType type, double a, double b, double c)
        {
            var p = (a+b+c)/2;
            var expArea = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            double[] parameters = { a, b, c };
            
            var shapes = new AreaShapes(type);

            var result = shapes.GetAreaShape(parameters);

            Assert.AreEqual(expArea, result);


            Assert.Pass();
        }

        /// <summary>
        /// Получить площадь треугольника, результат ArgumentException
        /// </summary>
        /// <param name="type"></param>
        /// <param name="radius"></param>
        /// <param name="expArea"></param>
        [TestCase(ShapeType.Triangle, 0, 3, 4)]
        [TestCase(ShapeType.Triangle, 2, -3, 4)]
        [TestCase(ShapeType.Triangle, null, 3, 4)] 
        [TestCase(ShapeType.Triangle, 2)] //Указано меньше сторон
        public void CalculateAreaOfTriangle_ShouldReturnExcepation(ShapeType type, double a, double b=0, double c=0)
        {
            double[] parameters;
            if (b == 0 && c == 0)//Проверяем с одним аргументом(case4)
                parameters = new double[] { a };
            else
                parameters = new double[] { a, b, c };

            var shapes = new AreaShapes(type);

            Assert.Throws<ArgumentException>(() => shapes.GetAreaShape(parameters));
        }
    }
}
