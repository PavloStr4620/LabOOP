﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {

            Console.WriteLine("Введіть x:");
            string inputX = Console.ReadLine();
            Console.WriteLine("Введіть y:");
            string inputY = Console.ReadLine();
            Console.WriteLine("Введіть z:");
            string inputZ = Console.ReadLine();

            int x, y, z;

            if (!int.TryParse(inputX, out x))
            {
                Console.WriteLine("Некоректне значення для x.");
                Console.ReadLine();
                return;
            }

            if (!int.TryParse(inputY, out y))
            {
                Console.WriteLine("Некоректне значення для y.");
                Console.ReadLine();
                return;

            }

            if (!int.TryParse(inputZ, out z))
            {
                Console.WriteLine("Некоректне значення для z.");
                Console.ReadLine();
                return;

            }


            double res = (Math.Cos(y) - (Math.Log(z) / (x - y)));
            double s = (y - x) * (res / (1 + Math.Pow((x - z), 2)));
            Console.WriteLine("Результат " + s);
            Console.ReadLine();
        }
    }
}