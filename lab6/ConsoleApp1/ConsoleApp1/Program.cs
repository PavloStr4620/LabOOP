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
            ZNO[] znoResults = new ZNO[]
            {
                new ZNO("Math", 150),
                new ZNO("Physics", 145),
                new ZNO("English", 100)
            };

            Entrant entrant = new Entrant("Ivan Petrenko", "1234567890", 4.95, true, znoResults);

            Console.WriteLine($"Best Subject: {entrant.GetBestSubject()}");

            Console.WriteLine($"Is On Top Of The Rating: {entrant.IsOnTopOfTheRating()}");

            Console.ReadLine();
        }
    }

    class ZNO
    {
        private string subject; // Назва предмета
        private int points;     // Кількість набраних балів

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

        public ZNO(string subject, int points)
        {
            this.subject = subject;
            this.points = points;
        }
    }


    class Entrant
    {
        private string fullName;   // Прізвище та ініціали
        private string idNum;      // Ідентифікаційний код
        private double avgPoints;  // Середній бал атестату
        private bool isAwarded;    // Чи нагороджений медаллю
        private ZNO[] znoResults;  // Массив результатів ЗНО

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        public string IdNum
        {
            get { return idNum; }
            set { idNum = value; }
        }

        public double AvgPoints
        {
            get { return avgPoints; }
            set { avgPoints = value; }
        }

        public bool IsAwarded
        {
            get { return isAwarded; }
            set { isAwarded = value; }
        }

        public ZNO[] ZNOResults
        {
            get { return znoResults; }
            set { znoResults = value; }
        }

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
            if (znoResults == null || znoResults.Length == 0)
                return "No ZNO results";

            ZNO bestZNO = znoResults[0];
            foreach (var zno in znoResults)
            {
                if (zno.Points > bestZNO.Points)
                    bestZNO = zno;
            }
            return bestZNO.Subject;
        }

        public bool IsOnTopOfTheRating()
        {
            return isAwarded && avgPoints >= 4.9;
        }
    }

}
