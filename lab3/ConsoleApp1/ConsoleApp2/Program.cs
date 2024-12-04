using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введіть кількість рядків масиву (n): ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введіть кількість стовпців масиву (m): ");
            int m = int.Parse(Console.ReadLine());

            double[,] array = new double[n, m];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = Math.Round(rnd.NextDouble() * (110.35 - (-110.34)) + (-110.34), 2);
                }
            }

            Console.WriteLine("Початковий масив: ");
            PrintArray(array);

            double[] maxInColumns = new double[m];
            for (int j = 0; j < m; j++)
            {
                double max = array[0, j];
                for (int i = 1; i < n; i++)
                {
                    if (array[i, j] > max) max = array[i, j];
                }
                maxInColumns[j] = max;
            }
            double minAmongMax = maxInColumns[0];
            for (int j = 1; j < m; j++)
            {
                if (maxInColumns[j] < minAmongMax) minAmongMax = maxInColumns[j];
            }
            Console.WriteLine("\nНайбільші елементи у кожному стовпці: ");
            foreach (var max in maxInColumns) Console.Write($"{max:F2} ");
            Console.WriteLine($"\nНайменший серед них: {minAmongMax:F2}");

            ReverseRows(array);

            Console.WriteLine("\nМасив після зміни порядку елементів у рядках: ");
            PrintArray(array);
        }

        static void PrintArray(double[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write($"{array[i, j],8:F2} ");
                }
                Console.WriteLine();
            }
        }

        static void ReverseRows(double[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int start = 0, end = cols - 1;
                while (start < end)
                {
                    double temp = array[i, start];
                    array[i, start] = array[i, end];
                    array[i, end] = temp;
                    start++;
                    end--;
                }
            }
        }
    }
}
