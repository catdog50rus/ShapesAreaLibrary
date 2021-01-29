# ShapesAreaLibrary
Библиотека для расчета площади фигур
Для добавления фгур в библиотеку, необходиморасширить список фигур

    public enum ShapeType
    {
        None,
        Circle,
        Triangle
    }

И реализовать приватный метод расчета площади

        private double GetAraOfTriangle(double [] sides)
        {
            if (sides.Length != 3)
                throw new ArgumentException("В треугольнике должно быть указано три стороны");
            double sideA = sides[0], sideB = sides[1], sideC = sides[2];
            var p = sides.Sum()/2 ; // (sideA + sideB + sideC) / 2;
            var area = Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));
            return area;
        }
        
В методе GetAreaShape(params double[] parameters)
добавить соответствующий CASE

        case ShapeType.Circle:
            result = GetAreaOfCircle(parameters);
            break;
            
Для самоконтроля можно добавить UnitTests для тестирования нахождения площади новой фигуры
