using System;

namespace CalculateAreaShapes.Library
{
    public class Circle : Shape
    {
        public Circle() { }

        /// <summary>
        /// Рассчитать площадь круга
        /// </summary>
        /// <param name="radius">Радиус круга</param>
        /// <returns></returns>
        public override double GetAreaShape(params double[] parameters)
        {
            ValidateParameters(parameters);
            //Получаем радиус из параметров
            var radius = parameters[0];
            //Возвращаем площадь круга
            //S = П*R*R
            return Math.PI * Math.Pow(radius, 2);
        }
        /// <summary>
        /// Валидация параметров
        /// </summary>
        /// <param name="parameters"></param>
        private static void ValidateParameters(double[] parameters)
        {
            //Первичная валидация входных параметров
            ValidateInputParameters(parameters);
            //Валидация количества параметров
            //У круга только один параметр радиус
            if (parameters.Length != 1)
                throw new ArgumentException("У окружности должен быть только один параметр (Радиус)");
        }
    }
}
