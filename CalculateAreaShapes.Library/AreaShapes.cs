using System;
using System.Linq;

namespace CalculateAreaShapes.Labrary
{
    public struct AreaShapes
    {
        private readonly ShapeType _shapeType;
        /// <summary>
        /// Флаг признака прямоугольного треугольника
        /// </summary>
        private bool _isRightЕriangle;
        
        public AreaShapes(ShapeType shapeType)
        {
            _shapeType = shapeType;
            _isRightЕriangle = default;
        }

        /// <summary>
        /// Рассчитать площадь фигуры
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public double GetAreaShape(params double[] parameters)
        {
            //Первичная валидация входных параметров
            ValidateInputParameters(parameters);

            //объявляем результирующую переменную и в зависимсти от типа фигуры вызываем необходимый метод
            double result = 0;
            switch (_shapeType)
            {
                case ShapeType.None:
                    break;
                case ShapeType.Circle:
                    result = GetAreaOfCircle(parameters);
                    break;
                case ShapeType.Triangle:
                    result = GetAraOfTriangle(parameters);
                    break;
                default:
                    break;
            }

            return result;
        }
        /// <summary>
        /// Проверить является ли треугольник прямоугольным
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public bool IsRightTriangle(double[] parameters)
        {
            //Первичная валидация входных параметров
            ValidateInputParameters(parameters);
            //Вызываем метод расчета площади треугольника, т.к. в этом методе реализоваа проверка на прямоугольный треугольник
            //и реализована проверка числа входных параметров 
            GetAraOfTriangle(parameters);
            return _isRightЕriangle;
        }

        /// <summary>
        /// Первичная валидация входных параметров
        /// </summary>
        /// <param name="parameters"></param>
        private static void ValidateInputParameters(double[] parameters)
        {
            //Валидация входных параметров
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
        /// <summary>
        /// Рассчитать площадь круга
        /// </summary>
        /// <param name="radius"></param>
        /// <returns></returns>
        private double GetAreaOfCircle(double[] radius)
        {
            if (radius.Length != 1)
                throw new ArgumentException("У окружности должен быть только один параметр (Радиус)");
            return Math.PI * Math.Pow(radius[0], 2);
        }
        /// <summary>
        /// Рассчитать площадь треугольника
        /// </summary>
        /// <param name="sides"></param>
        /// <returns></returns>
        private double GetAraOfTriangle(double [] sides)
        {
            if (sides.Length != 3)
                throw new ArgumentException("В треугольнике должно быть указано три стороны");
            sides.ToList().Sort();
            //Получаем стороны треугольника из массива
            double sideA = sides[0], sideB = sides[1], sideC = sides[2];

            //Проверка на прямоугольный треугольник
            if (Math.Pow(sideC, 2) == Math.Pow(sideA, 2) + Math.Pow(sideB, 2)) 
            {
                _isRightЕriangle = true;
                return sideA * sideB / 2;
            }
               

            var p = sides.Sum()/2; 
            var area = Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
            return area;
        }

    }

    public enum ShapeType
    {
        None,
        Circle,
        Triangle
    }
}
