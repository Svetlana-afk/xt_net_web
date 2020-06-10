using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int choise;
            bool succes = true;
            List<Shape> shapes = new List<Shape>();
            Console.WriteLine("Пожалуйста, введите Ваше имя.");
            User user = new User(Console.ReadLine());
            Console.WriteLine("Здравствуйте, {0}!", user.Name);
            
            while (succes) 
            {
                Console.WriteLine("{0}, выберите действие: " +
                    "\r\n 1. Добавить фигуру; " +
                    "\r\n 2. Вывести фигуры; " +
                    "\r\n 3. Очистить холст; " +
                    "\r\n 4. Сменить пользователя; " +
                    "\r\n 5. Выход.", user.Name);
                if (Int32.TryParse(Console.ReadLine(), out choise) && (choise <= 5) && (choise > 0))
                {
                    switch (choise)
                    {
                        case 1:

                            ShapeMenu();
                            break;

                        case 2:
                            foreach (var item in shapes)
                            {
                                Console.WriteLine(item.GetInfo()); 
                            }
                            break;

                        case 3:
                            shapes.Clear();
                            Console.WriteLine("{0}, все фигуры удалены с холста.", user.Name);
                            break;

                        case 4:
                            Console.WriteLine("До свидания, {0}." +
                                "\r\n Новый пользователь, пожалуйста, введите свое имя", user.Name);
                            user.Name = Console.ReadLine();
                            Console.WriteLine("Здравствуйте, {0}!", user.Name);
                            break;

                        case 5:
                            succes = false;
                            Console.WriteLine("Как?! Вы уже уходите? Хорошего дня, {0}!", user.Name);
                            break;
                    }
                }
                else 
                {
                    Console.WriteLine("Некорректный ввод.");
                }               
            }  
            
            void ShapeMenu() 
            {
                Console.WriteLine("{0}, выберите тип фигуры:" +
                               "\r\n 1. Окружность; " +
                               "\r\n 2. Круг; " +
                               "\r\n 3. Кольцо;" +
                               "\r\n 4. Линия; " +
                               "\r\n 5. Треугольник; " +
                               "\r\n 6. Прямоугольник; " +
                               "\r\n 7. Квадрад; ", user.Name);
                if (Int32.TryParse(Console.ReadLine(), out choise) && (choise <= 7) && (choise > 0))
                {
                    shapes.Add(FigureCreator.Create((FigureCreator.FigureType)choise));
                }
            }
        }
             
        
    }
}
