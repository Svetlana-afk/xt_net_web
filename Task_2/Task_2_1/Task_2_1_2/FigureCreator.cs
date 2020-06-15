using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2
{
    public class FigureCreator
    {
        public enum FigureType
        {
            None = 0,
            Circle = 1,
            Disk = 2,
            Ring = 3,
            Line = 4,
            Triangle = 5,
            Rectangle = 6,
            Square = 7
        }

        public static int GetIntFromInput(string str) 
        {
            bool succes = false;
            int x = -1;
            while (!succes)
            {
                Console.WriteLine(str);
                succes = int.TryParse(Console.ReadLine(), out x);
                if (!succes)
                {
                    Console.WriteLine("Некорректный ввод.");
                }
            }
            return x;
        }
        public static double GetPositiveDoubleFromInput(string str)
        {
            bool succes = false;
            double x = -1;
            while (!succes)
            {
                Console.WriteLine(str);
                succes = double.TryParse(Console.ReadLine(), out x);
                succes = succes && (x > 0);
                if (!succes || x <= 0)
                {
                    Console.WriteLine("Некорректный ввод.");
                }
            }
            return x;
        }
        private static Point CreatePoint()
        {
            int x = GetIntFromInput("Введите координату X центра фигуры:");
            int y = GetIntFromInput("Введите координату Y центра фигуры:");
            return new Point(x, y);
        }
        private static Circle CreateCircle()
        {                       
            Point p = CreatePoint();
            double radius = GetPositiveDoubleFromInput("Введите Радиус окружности:");
            Circle circle = new Circle(p, radius);
            Console.WriteLine("Окружность создана!");
            return circle;
        }

        private static Disk CreateDisk()
        {            
            Point p = CreatePoint();
            double radius = GetPositiveDoubleFromInput("Введите Радиус Круга:");
            Disk disk = new Disk(p, radius);
            Console.WriteLine("Круг создан!");
            return disk;
        }

        private static Ring CreateRing()
        {
            Point p = CreatePoint();
            double outerRadius = GetPositiveDoubleFromInput("Введите внешний Радиус кольца:");

            double innerRadius = -1;
            bool succes = false;          
            
            while (!succes || innerRadius >= outerRadius)
            {
                Console.WriteLine("Введите внутренний Радиус кольца:");
                succes = double.TryParse(Console.ReadLine(), out innerRadius);
                succes = succes && (innerRadius > 0) && (innerRadius < outerRadius);
                if (!succes)
                {
                    Console.WriteLine("Некорректный ввод.");
                }
            }
            Ring ring = new Ring(p, outerRadius, innerRadius);
            Console.WriteLine("Кольцо создано!");
            return ring;
        }

        private static Line CreateLine()
        {
            Point p = CreatePoint();
            double length = GetPositiveDoubleFromInput("Введите длину линии:");
           
            Line line = new Line(p, length);
            Console.WriteLine("Линия создана!");
            return line;
        }
        private static EquilateralTriangle CreateEquilateralTriangle()
        {
            Point p = CreatePoint();
            double sideA = GetPositiveDoubleFromInput("Введите длину стороны равностороннего треугольника:");                     
           
            EquilateralTriangle triangle = new EquilateralTriangle(p, sideA);
            Console.WriteLine("Равносторонний треугольник создан!");
            return triangle;
        }

        private static Rectangle CreateRectangle() 
        {
            Point p = CreatePoint();
            double sideA = GetPositiveDoubleFromInput("Введите длину стороны A прямоугольника:");
            double sideB = GetPositiveDoubleFromInput("Введите длину стороны B прямоугольника:");
            
            Rectangle rectangle = new Rectangle(p, sideA, sideB);
            Console.WriteLine("Прямоугольник создан!");
            return rectangle;
        }

        private static Square CreateSquare() 
        {
            Point p = CreatePoint();
            double sideA = GetPositiveDoubleFromInput("Введите длину стороны квадрата:");            

            Square square = new Square(p, sideA);
            Console.WriteLine("Квадрат создан!");
            return square;
        }

        public static Shape Create(FigureType figureType) 
        {
           
            switch (figureType) 
            {
                case FigureType.Circle:
                    return CreateCircle();                    

                case FigureType.Disk:
                    return CreateDisk();

                case FigureType.Ring:
                    return CreateRing();                    

                case FigureType.Line:
                    return CreateLine();                    

                case FigureType.Triangle:
                    return CreateEquilateralTriangle();                    

                case FigureType.Rectangle:
                    return CreateRectangle();                   

                case FigureType.Square:
                    return CreateSquare();
                    
                default: return null;
            }

            
           
        }
        
    }
    
}
