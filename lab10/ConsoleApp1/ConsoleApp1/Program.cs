using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Головне меню ===");
                Console.WriteLine("1. Демонстрація роботи з List");
                Console.WriteLine("2. Демонстрація роботи з Dictionary");
                Console.WriteLine("3. Вихід");
                Console.Write("Оберіть пункт меню: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ListMenu();
                        break;
                    case "2":
                        DictionaryMenu();
                        break;
                    case "3":
                        Console.WriteLine("До побачення!");
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
                Console.WriteLine("Натисніть будь-яку клавішу для повернення до меню...");
                Console.ReadKey();
            }
        }

        static void ListMenu()
        {
            var stringList = new List<string> { "Apple", "Banana", "Cherry" };
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Робота з List ===");
                Console.WriteLine("1. Вивести список");
                Console.WriteLine("2. Додати елемент");
                Console.WriteLine("3. Видалити елемент");
                Console.WriteLine("4. Пошук елемента");
                Console.WriteLine("5. Очистити список");
                Console.WriteLine("6. Повернутись до головного меню");
                Console.Write("Оберіть пункт: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Список елементів:");
                        stringList.ForEach(Console.WriteLine);
                        break;
                    case "2":
                        Console.Write("Введіть елемент для додавання: ");
                        var itemToAdd = Console.ReadLine();
                        stringList.Add(itemToAdd);
                        Console.WriteLine($"Елемент '{itemToAdd}' додано.");
                        break;
                    case "3":
                        Console.Write("Введіть елемент для видалення: ");
                        var itemToRemove = Console.ReadLine();
                        if (stringList.Remove(itemToRemove))
                        {
                            Console.WriteLine($"Елемент '{itemToRemove}' видалено.");
                        }
                        else
                        {
                            Console.WriteLine($"Елемент '{itemToRemove}' не знайдено.");
                        }
                        break;
                    case "4":
                        Console.Write("Введіть елемент для пошуку: ");
                        var itemToFind = Console.ReadLine();
                        Console.WriteLine(stringList.Contains(itemToFind)
                            ? $"Елемент '{itemToFind}' знайдено."
                            : $"Елемент '{itemToFind}' не знайдено.");
                        break;
                    case "5":
                        stringList.Clear();
                        Console.WriteLine("Список очищено.");
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
                Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
            }
        }

        static void DictionaryMenu()
        {
            var entrants = new Dictionary<int, Entrant>
            {
                { 1, new Entrant(1, "Alice", 95.5) },
                { 2, new Entrant(2, "Bob", 88.0) }
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Робота з Dictionary ===");
                Console.WriteLine("1. Вивести словник");
                Console.WriteLine("2. Додати елемент");
                Console.WriteLine("3. Видалити елемент");
                Console.WriteLine("4. Пошук елемента");
                Console.WriteLine("5. Очистити словник");
                Console.WriteLine("6. Повернутись до головного меню");
                Console.Write("Оберіть пункт: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Словник:");
                        foreach (var pair in entrants)
                        {
                            Console.WriteLine($"Ключ: {pair.Key}, Значення: {pair.Value}");
                        }
                        break;
                    case "2":
                        Console.Write("Введіть ключ (int): ");
                        if (int.TryParse(Console.ReadLine(), out int key))
                        {
                            Console.Write("Введіть ім'я: ");
                            var name = Console.ReadLine();
                            Console.Write("Введіть бал (double): ");
                            if (double.TryParse(Console.ReadLine(), out double score))
                            {
                                entrants[key] = new Entrant(key, name, score);
                                Console.WriteLine("Елемент додано.");
                            }
                            else
                            {
                                Console.WriteLine("Невірний формат балу.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Невірний формат ключа.");
                        }
                        break;
                    case "3":
                        Console.Write("Введіть ключ для видалення: ");
                        if (int.TryParse(Console.ReadLine(), out int keyToRemove) && entrants.Remove(keyToRemove))
                        {
                            Console.WriteLine("Елемент видалено.");
                        }
                        else
                        {
                            Console.WriteLine("Елемент із таким ключем не знайдено.");
                        }
                        break;
                    case "4":
                        Console.Write("Введіть ключ для пошуку: ");
                        if (int.TryParse(Console.ReadLine(), out int keyToFind) && entrants.TryGetValue(keyToFind, out var entrant))
                        {
                            Console.WriteLine($"Знайдено: {entrant}");
                        }
                        else
                        {
                            Console.WriteLine("Елемент із таким ключем не знайдено.");
                        }
                        break;
                    case "5":
                        entrants.Clear();
                        Console.WriteLine("Словник очищено.");
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
                Console.WriteLine("Натисніть будь-яку клавішу для продовження...");
                Console.ReadKey();
            }
        }
    }

    class Entrant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Score { get; set; }

        public Entrant(int id, string name, double score)
        {
            Id = id;
            Name = name;
            Score = score;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Score: {Score}";
        }
    }
}
