using System;

namespace CalculateAreaShapes.Library
{
    public class Circle : Shape
    {
        private readonly double _radius;

        public Circle(double radius):base(radius)
        {
            _radius = _parameters[0];
        }

        /// <summary>
        /// Рассчитать площадь круга
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        /// <returns></returns>
        public override double GetAreaShape()
        {
            //S = П*R*R
            return Math.PI * Math.Pow(_radius, 2);
        }

    }
}
