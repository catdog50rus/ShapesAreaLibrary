using System;

namespace CalculateAreaShapes.Library
{
    public abstract class Shape
    {
        protected readonly double[] _parameters;

        protected Shape(params double[] parameters)
        {
            ValidateInputParameters(parameters);
            _parameters = parameters;
        }

        /// <summary>
        /// Рассчитать площадь фигуры
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        abstract public double GetAreaShape();
        /// <summary>
        /// Первичная валидация параметров
        /// </summary>
        /// <param name="parameters"></param>
        protected void ValidateInputParameters(double[] parameters)
        {
            //Пустой массив
            if (parameters.Length == 0)
                throw new ArgumentException("Входные параметры пустые");
            //Массив содержит 0 или отрицательное число
            foreach (var item in parameters)
            {
                if (item <= 0)
                    throw new ArgumentException("Один из входных параметров отрицательное число");
                if (item == 0)
                    throw new ArgumentException("Один из входных параметров равен 0");
            }
        }
    }
}
