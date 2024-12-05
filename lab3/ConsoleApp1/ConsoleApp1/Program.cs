using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Введіть кількість елементів масиву (n): ");
            int n = int.Parse(Console.ReadLine());

            double[] array = new double[n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                array[i] = Math.Round(rnd.NextDouble() * (18.3 - (-14.2)) + (-14.2), 1);
            }

            Console.WriteLine("Початковий масив: ");
            PrintArray(array);

            int minIndex = 0, maxIndex = 0;
            for (int i = 1; i < n; i++)
            {
                if (array[i] < array[minIndex]) minIndex = i;
                if (array[i] > array[maxIndex]) maxIndex = i;
            }

            Console.WriteLine($"\nМінімальний елемент: {array[minIndex]} (індекс {minIndex})");
            Console.WriteLine($"Максимальний елемент: {array[maxIndex]} (індекс {maxIndex})");

            if (minIndex > maxIndex)
            {
                int temp = minIndex;
                minIndex = maxIndex;
                maxIndex = temp;
            }

            int sumIndexes = 0;
            for (int i = minIndex + 1; i < maxIndex; i++)
            {
                sumIndexes += i;
            }
            Console.WriteLine($"\nСума індексів між мінімальним та максимальним елементами: {sumIndexes}");

            ReverseSubArray(array, minIndex + 1, maxIndex - 1);

            Console.WriteLine("\nМасив після зміни порядку елементів між мінімальним та максимальним: ");
            PrintArray(array);
        }

        static void PrintArray(double[] array)
        {
            foreach (double num in array)
            {
                Console.Write($"{num:F1} ");
            }
            Console.WriteLine();
        }

        static void ReverseSubArray(double[] array, int start, int end)
        {
            while (start < end)
            {
                double temp = array[start];
                array[start] = array[end];
                array[end] = temp;
                start++;
                end--;
            }
        }
    }
}
