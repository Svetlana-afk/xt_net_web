using System;
using System.Collections.Generic;
using System.Linq;
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
            Disc = 2,
            Ring = 3,
            Line = 4,
            Triangle = 5,
            Rectangle = 6,
            Square = 7
        }
        private static Point CreatePoint() 
        {
            bool succes = false;
            int x = -1;
            int y = -1;
            while (!succes)
            {
                Console.WriteLine("Введите координату X центра фигуры:");
                succes = Int32.TryParse(Console.ReadLine(), out x);
                if (!succes)
                {
                    Console.WriteLine("Некорректный ввод");
                }
            }
            succes = false;
            while (!succes)
            {
                Console.WriteLine("Введите координату Y центра фигуры:");
                succes = Int32.TryParse(Console.ReadLine(), out y);
                if (!succes)
                {
                    Console.WriteLine("Некорректный ввод.");
                }
            }
            return new Point(x, y);
        }
        public static Shape Create(FigureType figureType) 
        {
           
            switch (figureType) 
            {
                case (FigureType)1:
                    double radius = -1;
                    bool succes = false;   
                    succes = false;
                    Point p = CreatePoint();

                    while (!succes || radius <= 0)
                    {
                        Console.WriteLine("Введите Радиус окружности:");
                        succes = Double.TryParse(Console.ReadLine(), out radius);
                        if (!succes || radius <= 0)
                        {
                            Console.WriteLine("Некорректный ввод.");
                        }
                    } 
                    Shape circle = new Circle(p, radius);
                    Console.WriteLine("Окружность создана!");
                    return circle;

                case (FigureType)2:                    
                    radius = -1;
                    succes = false;
                    p = CreatePoint();

                    while (!succes || radius <= 0)
                    {
                        Console.WriteLine("Введите Радиус круга:");
                        succes = Double.TryParse(Console.ReadLine(), out radius);
                        if (!succes || radius <= 0)
                        {
                            Console.WriteLine("Некорректный ввод.");
                        }
                    }
                    Shape disk = new Disk(p, radius);
                    Console.WriteLine("Круг создан!");
                    return disk;

                case (FigureType)3:
                    radius = -1;
                    double innerRadius = -1;
                    succes = false;
                    p = CreatePoint();
                    while (!succes)
                    {
                        Console.WriteLine("Введите внешний Радиус кольца:");
                        succes = Double.TryParse(Console.ReadLine(), out radius);
                        succes = succes && (radius > 0);
                        if (!succes)
                        {
                            Console.WriteLine("Некорректный ввод.");
                        }
                    }
                    succes = false;
                    while (!succes || innerRadius >= radius)
                    {
                        Console.WriteLine("Введите внутренний Радиус кольца:");
                        succes = Double.TryParse(Console.ReadLine(), out innerRadius);
                        succes = succes && (innerRadius > 0)&& (innerRadius < radius);
                        if (!succes)
                        {
                            Console.WriteLine("Некорректный ввод.");
                        }
                    }                    
                    Shape ring = new Ring(p, radius, innerRadius);
                    Console.WriteLine("Кольцо создано!");
                    return ring;

                case (FigureType)4:
                    double length = -1;
                    succes = false;
                    p = CreatePoint();

                    while (!succes)
                    {
                        Console.WriteLine("Введите длину линии:");
                        succes = Double.TryParse(Console.ReadLine(), out length);
                        succes = succes && (length > 0);
                        if (!succes)
                        {
                            Console.WriteLine("Некорректный ввод.");
                        }
                    }
                    Shape line = new Line(p, length);
                    Console.WriteLine("Линия создана!");
                    return line;

                case (FigureType)5:
                    double sideA = -1;                    
                    succes = false;
                    p = CreatePoint();

                    while (!succes)
                    {
                        Console.WriteLine("Введите длину стороны равностороннего треугольника:");
                        succes = Double.TryParse(Console.ReadLine(), out sideA);
                        succes = succes && (sideA > 0);
                        if (!succes)
                        {
                            Console.WriteLine("Некорректный ввод.");
                        }
                    }
                    Shape triangle = new Triangle(p, sideA);
                    Console.WriteLine("Треугольник создан!");
                    return triangle;

                case (FigureType)6:
                    sideA = -1;
                    double sideB = -1;
                    succes = false;
                    p = CreatePoint();

                    while (!succes)
                    {
                        Console.WriteLine("Введите длину стороны A прямоугольника:");
                        succes = Double.TryParse(Console.ReadLine(), out sideA);
                        succes = succes && (sideA > 0);
                        if (!succes)
                        {
                            Console.WriteLine("Некорректный ввод.");
                        }
                    }
                    succes = false;
                    while(!succes)
                    {
                        Console.WriteLine("Введите длину стороны B прямоугольника:");
                        succes = Double.TryParse(Console.ReadLine(), out sideB);
                        succes = succes && (sideB > 0);
                        if (!succes)
                        {
                            Console.WriteLine("Некорректный ввод.");
                        }
                    }
                    Shape rectangle = new Rectangle(p, sideA, sideB);
                    Console.WriteLine("Прямоугольник создан!");
                    return rectangle;

                case (FigureType)7:
                    sideA = -1;                    
                    succes = false;
                    p = CreatePoint();

                    while (!succes)
                    {
                        Console.WriteLine("Введите длину стороны квадрата:");
                        succes = Double.TryParse(Console.ReadLine(), out sideA);
                        succes = succes && (sideA > 0);
                        if (!succes)
                        {
                            Console.WriteLine("Некорректный ввод.");
                        }
                    }
                    
                    Shape sqare = new Square(p, sideA);
                    Console.WriteLine("Квадрат создан!");
                    return sqare;
                default: return null;
            }

            
           
        }
        
    }
    
}
