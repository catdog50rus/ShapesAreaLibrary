using System;
using System.Linq;

namespace CalculateAreaShapes.Library
{
    public class Triangle : Shape
    {
        public Triangle() { }

        /// <summary>
        /// Рассчитать площадь треугольника
        /// </summary>
        /// <param name="sides">Длины сторон треугольника</param>
        /// <returns></returns>
        public override double GetAreaShape(params double[] sides)
        {
            //Валидация параметров
            ValidateParameters(sides);
            //Получаем стороны треугольника из массива
            double sideA = sides[0], sideB = sides[1], sideC = sides[2];
            //В общем случае площадь треугольника равна
            //S = SQRT(p * (p - sideA) * (p - sideB) * (p - sideC)),
            //где р - полупериметр треугольника
            var p = sides.Sum() / 2;
            var area = Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
            return area;
        }
        /// <summary>
        /// Проверить является ли треугольник прямоугольным
        /// </summary>
        /// <param name="sides"></param>
        /// <returns></returns>
        public bool IsRightTriangle(double[] sides)
        {
            //Валидация входных параметров
            ValidateParameters(sides);
            //Сортируем стороны по возрастанию
            sides.ToList().Sort();
            //Получаем стороны треугольника из массива
            double sideA = sides[0], sideB = sides[1], sideC = sides[2];

            //Проверяем треугольник  по теореме Пифагорана
            return (Math.Pow(sideC, 2) == Math.Pow(sideA, 2) + Math.Pow(sideB, 2));
        }
        /// <summary>
        /// Валидируем входные параметры
        /// </summary>
        /// <param name="sides"></param>
        private static void ValidateParameters(double[] sides)
        {
            //Первичная валидация входных параметров
            ValidateInputParameters(sides);
            //Валидация количества параметров
            //У треугольника только три параметра стороны
            if (sides.Length != 3)
                throw new ArgumentException("В треугольнике должно быть указано три стороны");
        }
  
    }
}
