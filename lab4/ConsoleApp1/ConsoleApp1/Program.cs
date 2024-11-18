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
            // Демонстрація роботи структури Angle
            Angle angle1 = new Angle(350, 45); // Кут 350° 45'
            Angle angle2 = new Angle(15, 30);  // Кут 15° 30'

            Console.WriteLine($"Кут 1: {angle1}");
            Console.WriteLine($"Кут 2: {angle2}");

            // Збільшення кута
            angle1.Increase(15, 30); // Додати 15° 30'
            Console.WriteLine($"\nКут 1 після збільшення: {angle1}");

            // Зменшення кута
            angle2.Decrease(10, 45); // Відняти 10° 45'
            Console.WriteLine($"Кут 2 після зменшення: {angle2}");

            // Обчислення синуса
            Console.WriteLine($"\nСинус кута 1: {angle1.Sin()}");
            Console.WriteLine($"Синус кута 2: {angle2.Sin()}");

            // Порівняння
            Console.WriteLine($"\nКут 1 == Кут 2: {angle1 == angle2}");
            Console.WriteLine($"Кут 1 > Кут 2: {angle1 > angle2}");
            Console.WriteLine($"Кут 1 < Кут 2: {angle1 < angle2}");
        }
    }

    public struct Angle
    {
        public int Degrees { get; private set; }
        public int Minutes { get; private set; }

        public Angle(int degrees, int minutes)
        {
            Degrees = degrees;
            Minutes = minutes;
            Normalize();
        }

        private void Normalize()
        {
            int totalMinutes = Degrees * 60 + Minutes;
            totalMinutes %= 360 * 60;

            if (totalMinutes < 0)
                totalMinutes += 360 * 60;

            Degrees = totalMinutes / 60;
            Minutes = totalMinutes % 60;
        }

        public double ToRadians()
        {
            double decimalDegrees = Degrees + Minutes / 60.0;
            return decimalDegrees * Math.PI / 180.0;
        }

        public void Increase(int degrees, int minutes)
        {
            Degrees += degrees;
            Minutes += minutes;
            Normalize();
        }

        public void Decrease(int degrees, int minutes)
        {
            Degrees -= degrees;
            Minutes -= minutes;
            Normalize();
        }

        public double Sin()
        {
            return Math.Sin(ToRadians());
        }

        public static bool operator ==(Angle a1, Angle a2)
        {
            return a1.Degrees == a2.Degrees && a1.Minutes == a2.Minutes;
        }

        public static bool operator !=(Angle a1, Angle a2)
        {
            return !(a1 == a2);
        }

        public static bool operator <(Angle a1, Angle a2)
        {
            return a1.ToRadians() < a2.ToRadians();
        }

        public static bool operator >(Angle a1, Angle a2)
        {
            return a1.ToRadians() > a2.ToRadians();
        }

        public static bool operator <=(Angle a1, Angle a2)
        {
            return a1.ToRadians() <= a2.ToRadians();
        }

        public static bool operator >=(Angle a1, Angle a2)
        {
            return a1.ToRadians() >= a2.ToRadians();
        }

        public override bool Equals(object obj)
        {
            if (obj is Angle other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Degrees.GetHashCode() ^ Minutes.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Degrees}° {Minutes}'";
        }
    }
}
