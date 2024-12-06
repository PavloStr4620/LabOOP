using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Кількість абітурієнтів: ");
            int n = int.Parse(Console.ReadLine());
            Entrant[] entrants = CreateEntrants(n);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Вивести інформацію про всіх абітурієнтів");
                Console.WriteLine("2. Вивести найкращий предмет абітурієнта");
                Console.WriteLine("3. Перевірити, чи абітурієнт в топі рейтингу");
                Console.WriteLine("4. Вийти");
                Console.Write("Ваш вибір: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        PrintAllEntrants(entrants);
                        break;
                    case 2:
                        Console.Write("Введіть індекс абітурієнта: ");
                        int index = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Найкращий предмет: {entrants[index].GetBestSubject()}");
                        break;
                    case 3:
                        Console.Write("Введіть індекс абітурієнта: ");
                        index = int.Parse(Console.ReadLine());
                        Console.WriteLine($"В топі рейтингу: {entrants[index].IsOnTopOfTheRating()}");
                        break;
                    case 4:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір!");
                        break;
                }
            }
        }

        // Статичний метод для створення масиву об'єктів
        public static Entrant[] CreateEntrants(int n)
        {
            Entrant[] entrants = new Entrant[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Введіть ПІБ: ");
                string name = Console.ReadLine();
                Console.Write("Введіть ID: ");
                string id = Console.ReadLine();
                Console.Write("Введіть середній бал: ");
                double avgPoints = double.Parse(Console.ReadLine());
                Console.Write("Нагороджений медаллю (true/false): ");
                bool isAwarded = bool.Parse(Console.ReadLine());
                Console.Write("Кількість предметів ЗНО: ");
                int m = int.Parse(Console.ReadLine());

                ZNO[] znoResults = new ZNO[m];
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"Предмет {j + 1}: ");
                    string subject = Console.ReadLine();
                    Console.Write($"Бали {j + 1}: ");
                    int points = int.Parse(Console.ReadLine());
                    znoResults[j] = new ZNO(subject, points);
                }

                entrants[i] = new Entrant(name, id, avgPoints, isAwarded, znoResults);
            }
            return entrants;
        }

        // Статичний метод для виведення об'єкта
        public static void PrintEntrant(Entrant entrant)
        {
            Console.WriteLine(entrant.ToString());
        }

        // Статичний метод для виведення всіх об'єктів
        public static void PrintAllEntrants(Entrant[] entrants)
        {
            foreach (var entrant in entrants)
            {
                PrintEntrant(entrant);
            }
        }
    }

    class ZNO
    {
        private string subject;
        private int points;

        public string Subject
        {
            get { return subject; }
            set { subject = value; }
        }

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public ZNO() { subject = "Undefined"; points = 0; }

        public ZNO(string subject, int points)
        {
            this.subject = subject;
            this.points = points;
        }

        public override string ToString() => $"Предмет: {subject}, Бали: {points}";
    }

    class Entrant
    {
        private string fullName;
        private string idNum;
        private double avgPoints;
        private bool isAwarded;
        private ZNO[] znoResults;

        public string FullName { get { return fullName; } set { fullName = value; } }
        public string IdNum { get { return idNum; } set { idNum = value; } }
        public double AvgPoints { get { return avgPoints; } set { avgPoints = value; } }
        public bool IsAwarded { get { return isAwarded; } set { isAwarded = value; } }
        public ZNO[] ZNOResults { get { return znoResults; } set { znoResults = value; } }

        public Entrant() { fullName = "Undefined"; idNum = "000000"; avgPoints = 0.0; isAwarded = false; znoResults = new ZNO[0]; }

        public Entrant(string fullName, string idNum, double avgPoints, bool isAwarded, ZNO[] znoResults)
        {
            this.fullName = fullName;
            this.idNum = idNum;
            this.avgPoints = avgPoints;
            this.isAwarded = isAwarded;
            this.znoResults = znoResults;
        }

        public string GetBestSubject()
        {
            if (znoResults.Length == 0) return "No subjects available.";
            ZNO best = znoResults[0];
            foreach (var zno in znoResults)
            {
                if (zno.Points > best.Points)
                    best = zno;
            }
            return best.Subject;
        }

        public bool IsOnTopOfTheRating() => isAwarded && avgPoints >= 4.9;

        public override string ToString() => $"Ім’я: {fullName}, ID: {idNum}, Середній бал: {avgPoints}, Медаль: {isAwarded}";
    }
}
