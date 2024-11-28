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
            
            if (minutes >= 60 || minutes < 0)
            {
                Console.WriteLine("Minutes must be between 0 and 59.");
            }
            Degrees = degrees;
            Minutes = minutes;
            NormalizeAngle();
        }

        
        public double ToRadians()
        {
            return (Degrees + Minutes / 60.0) * (Math.PI / 180.0);
        }

        
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

        
        public void Increase(int degreesToAdd, int minutesToAdd)
        {
            Degrees += degreesToAdd;
            Minutes += minutesToAdd;
            NormalizeAngle();
        }

        
        public void Decrease(int degreesToSubtract, int minutesToSubtract)
        {
            Degrees -= degreesToSubtract;
            Minutes -= minutesToSubtract;
            NormalizeAngle();
        }

        
        public double Sin()
        {
            return Math.Sin(ToRadians());
        }

        public bool EqualsTo(Angle other)
        {
            return this.Degrees == other.Degrees && this.Minutes == other.Minutes;
        }

       
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
                
                Angle angle = new Angle(45, 30);
                Console.WriteLine($"Кут: {angle}");

                Console.WriteLine($"Кут в радіанах: {angle.ToRadians()}");
                
                angle.Increase(10, 15);
                Console.WriteLine($"Після збільшення: {angle}");

                angle.Decrease(5, 45);
                Console.WriteLine($"Після зменшення: {angle}");

                Console.WriteLine($"Синус кута: {angle.Sin()}");

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
