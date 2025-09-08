using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace lab1
{
    public class Subscriber
    {
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string InstallYear { get; set; }
    }
    class Program
    {
        static void firstTask()
        {
            Console.WriteLine("Введите массу в килограммах: ");
            double weight = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите длину в метрах: ");
            double length = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите ширину в метрах: ");
            double width = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите высоту предмета в метрах: ");
            double height = Convert.ToDouble(Console.ReadLine());
            double density = (weight * 2) / (length * width * height);
            Console.WriteLine($"Плотность предмета {density} кг/м^3");
        }

        static void secondTask()
        {
            var subscribers = new List<Subscriber>
            {
                new Subscriber { LastName = "Иванов", PhoneNumber = "1277", InstallYear = "2015" },
                new Subscriber { LastName = "Петров", PhoneNumber = "2345", InstallYear = "1999" },
                new Subscriber { LastName = "Сидоров", PhoneNumber = "4577", InstallYear = "1977" },
                new Subscriber { LastName = "Кузнецов", PhoneNumber = "7811", InstallYear = "2011" },
                new Subscriber { LastName = "Смирнов", PhoneNumber = "3399", InstallYear = "2020" },
                new Subscriber { LastName = "Попов", PhoneNumber = "6688", InstallYear = "1988" },
                new Subscriber { LastName = "Васильев", PhoneNumber = "1233", InstallYear = "2023" }
            };

            string json = System.Text.Json.JsonSerializer.Serialize(subscribers, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("phone_directory.json", json);
            Console.WriteLine("Данные сохранены в файл 'phone_directory.json'");

            string jsonData = File.ReadAllText("phone_directory.json");
            List<Subscriber> data = System.Text.Json.JsonSerializer.Deserialize<List<Subscriber>>(jsonData);

            var filteredSubscribers = data.FindAll(s =>
                s.PhoneNumber.Length == 4 &&
                s.InstallYear.Length == 4 &&
                s.PhoneNumber.Substring(2, 2) == s.InstallYear.Substring(2, 2));

            Console.WriteLine("\nВсе абоненты:");
            foreach (var sub in data)
            {
                Console.WriteLine($"{sub.LastName,-10} {sub.PhoneNumber} ({sub.InstallYear})");
            }

            Console.WriteLine("\nАбоненты, у которых yy=бб: ");
            if (filteredSubscribers.Count > 0)
            {
                foreach (var sub in filteredSubscribers)
                {
                    string yy = sub.PhoneNumber.Substring(2, 2);
                    string bb = sub.InstallYear.Substring(2, 2);
                    Console.WriteLine($"{sub.LastName,-10} {sub.PhoneNumber} ({sub.InstallYear}) - yy={yy}, бб={bb}");
                }
            }
            else
            {
                Console.WriteLine("Абонентов, удовлетворяющих условию, не найдено.");
            }
        }

        static void Main()
        {
            Console.WriteLine("Фенько Андрей - Вариант 8\n1. Решение задачи про плотность.\n2. Задача про телефонный справочник.\n");

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
                    Console.WriteLine("\nВыбранного пункта не существует!\n");
                    break;
            }
        }
    }
}