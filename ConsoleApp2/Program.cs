using ClassLibrary1;
using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var area = new AreaShapes(ShapeType.Circle).GetAreaShape(4);

            Console.WriteLine(area);

        }
    }
}
