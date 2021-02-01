using System;
using System.Linq;

namespace CalculateAreaShapes.Library
{
    public class Triangle : Shape
    {
        private readonly double _sideA;
        private readonly double _sideB;
        private readonly double _sideC;
        
        public Triangle(double[] parameters):base(parameters) 
        {
            ValidateParameters(_parameters);
            Array.Sort(_parameters);
            _sideA = _parameters[0];
            _sideB = _parameters[1];
            _sideC = _parameters[2];
        }

        /// <summary>
        /// Рассчитать площадь треугольника
        /// </summary>
        /// <param name="sides">Длины сторон треугольника</param>
        /// <returns></returns>
        public override double GetAreaShape()
        {
            //В общем случае площадь треугольника равна
            //S = SQRT(p * (p - sideA) * (p - sideB) * (p - sideC)),
            //где р - полупериметр треугольника
            var p = _parameters.Sum() / 2;
            var area = Math.Sqrt(p * (p - _sideA) * (p - _sideB) * (p - _sideC));
            return area;
        }
        /// <summary>
        /// Проверить является ли треугольник прямоугольным по теореме Пифагорана
        /// </summary>
        /// <param name="sides"></param>
        /// <returns></returns>
        public bool IsRightTriangle()
        {
            return (Math.Pow(_sideC, 2) == Math.Pow(_sideA, 2) + Math.Pow(_sideB, 2));
        }

        /// <summary>
        /// Валидируем входные параметры треугольника
        /// </summary>
        /// <param name="sides"></param>
        private static void ValidateParameters(double[] sides)
        {
            if (sides.Length != 3)
                throw new ArgumentException("В треугольнике должно быть указано три стороны");
        }
  
    }
}
