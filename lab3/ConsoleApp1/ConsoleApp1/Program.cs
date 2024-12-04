using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Введення розміру масиву
            Console.Write("Введіть кількість елементів масиву (n): ");
            int n = int.Parse(Console.ReadLine());

            // Оголошення та ініціалізація масиву випадковими числами
            double[] array = new double[n];
            Random rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                // Генерація випадкових чисел у діапазоні [-14.2, 18.3] з точністю до 1 дробового знака
                array[i] = Math.Round(rnd.NextDouble() * (18.3 - (-14.2)) + (-14.2), 1);
            }

            Console.WriteLine("Початковий масив: ");
            PrintArray(array);

            // Знаходимо індекси мінімального та максимального елементів
            int minIndex = 0, maxIndex = 0;
            for (int i = 1; i < n; i++)
            {
                if (array[i] < array[minIndex]) minIndex = i;
                if (array[i] > array[maxIndex]) maxIndex = i;
            }

            Console.WriteLine($"\nМінімальний елемент: {array[minIndex]} (індекс {minIndex})");
            Console.WriteLine($"Максимальний елемент: {array[maxIndex]} (індекс {maxIndex})");

            // Гарантуємо, що minIndex менший за maxIndex
            if (minIndex > maxIndex)
            {
                int temp = minIndex;
                minIndex = maxIndex;
                maxIndex = temp;
            }

            // Завдання 1: Знайти суму індексів елементів між мінімальним і максимальним
            int sumIndexes = 0;
            for (int i = minIndex + 1; i < maxIndex; i++)
            {
                sumIndexes += i;
            }
            Console.WriteLine($"\nСума індексів між мінімальним та максимальним елементами: {sumIndexes}");

            // Завдання 2: Змінити порядок елементів між мінімальним та максимальним на протилежний
            ReverseSubArray(array, minIndex + 1, maxIndex - 1);

            Console.WriteLine("\nМасив після зміни порядку елементів між мінімальним та максимальним: ");
            PrintArray(array);
        }

        // Функція для виведення масиву
        static void PrintArray(double[] array)
        {
            foreach (double num in array)
            {
                Console.Write($"{num:F1} ");
            }
            Console.WriteLine();
        }

        // Функція для реверсу частини масиву
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
