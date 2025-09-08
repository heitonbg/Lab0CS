using System;

namespace lab1
{
    class Program
    {
        static void firstTask()
        {
            Console.WriteLine("Введите массу: ");
            double weight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите длину: ");
            double length = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите ширину: ");
            double width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите высоту предмета: ");
            int height = Convert.ToInt32(Console.ReadLine());
            double density = (weight * 2) / (length * width * height);
            Console.WriteLine($"Ваш ответ {density}");
        }

        static void secondTask()
        {

        }

        static void Main()
        {
            Console.WriteLine("1. Возведение в степень.\n2. Переместить вторую цифру в конец.\n");

            Console.Write("Введите выбранный пункт: ");
            string UserAnswer = Console.ReadLine();

            switch (UserAnswer)
            {
                case "1":
                    firstTask();
                    break;
                case "2":
                    secondTask();
                    break;
                default:
                    Console.WriteLine("\nВыбранного пункта не существует! Повторите попытку!\n");
                    break;
            }
        }
    }
}