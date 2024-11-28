using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal struct Angle
    {
        public int Degrees { get; set; } //градуси
        public int Minutes { get; set; } //хвилини

        public Angle(int degrees, int minutes)
        {
            // Переконуємося, що хвилини знаходяться в межах [0, 59]
            if (minutes >= 60 || minutes < 0)
            {
                Console.WriteLine("Minutes must be between 0 and 59.");
            }
            Degrees = degrees;
            Minutes = minutes;
            NormalizeAngle();
        }

        // Переведення кута в радіани
        public double ToRadians()
        {
            return (Degrees + Minutes / 60.0) * (Math.PI / 180.0);
        }

        // Приведення кута до діапазону 0-360 (градації в 360-ті частки)
        public void NormalizeAngle()
        {
            while (Degrees < 0)
            {
                Degrees += 360;
            }
            while (Degrees >= 360)
            {
                Degrees -= 360;
            }
            if (Minutes < 0)
            {
                Degrees--;
                Minutes += 60;
            }
            if (Minutes >= 60)
            {
                Degrees++;
                Minutes -= 60;
            }
        }

        // Операція збільшення кута на задану величину
        public void Increase(int degreesToAdd, int minutesToAdd)
        {
            Degrees += degreesToAdd;
            Minutes += minutesToAdd;
            NormalizeAngle();
        }

        // Операція зменшення кута на задану величину
        public void Decrease(int degreesToSubtract, int minutesToSubtract)
        {
            Degrees -= degreesToSubtract;
            Minutes -= minutesToSubtract;
            NormalizeAngle();
        }

        // Обчислення синуса кута
        public double Sin()
        {
            return Math.Sin(ToRadians());
        }

        // Порівняння кутів без використання операторів
        public bool EqualsTo(Angle other)
        {
            return this.Degrees == other.Degrees && this.Minutes == other.Minutes;
        }

        // Для зручності виведення
        public override string ToString()
        {
            return $"{Degrees}° {Minutes}'";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Створення кута
                Angle angle = new Angle(45, 30);
                Console.WriteLine($"Кут: {angle}");

                // Переведення в радіани
                Console.WriteLine($"Кут в радіанах: {angle.ToRadians()}");

                // Збільшення кута
                angle.Increase(10, 15);
                Console.WriteLine($"Після збільшення: {angle}");

                // Зменшення кута
                angle.Decrease(5, 45);
                Console.WriteLine($"Після зменшення: {angle}");

                // Обчислення синуса кута
                Console.WriteLine($"Синус кута: {angle.Sin()}");

                // Порівняння двох кутів без використання операторів
                Angle angle2 = new Angle(49, 0);
                Console.WriteLine($"Кути рівні? {angle.EqualsTo(angle2)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}
