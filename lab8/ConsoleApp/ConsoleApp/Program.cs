using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Demonstrate Animal, Fish, and Bird classes");
                Console.WriteLine("2. Demonstrate Fraction class");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DemonstrateAnimalClasses();
                        break;
                    case 2:
                        DemonstrateFractionClass();
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }

        static void DemonstrateAnimalClasses()
        {
            // Array of derived objects
            Animal[] animals = new Animal[]
            {
                new Fish(1, 3.2, "Female", "Freshwater"),
                new Bird(2, 1.5, "Male", true)
            };

            Console.WriteLine("\nAnimal Info:");
            foreach (var animal in animals)
            {
                animal.ShowInfo();
            }
        }

        static void DemonstrateFractionClass()
        {
            Fraction fraction1 = new Fraction(4, 8);
            Fraction fraction2 = new Fraction(3, 5);

            Console.WriteLine("\nFractions:");
            Console.WriteLine($"Fraction1: {fraction1}");
            Console.WriteLine($"Fraction2: {fraction2}");

            Fraction sum = fraction1 + fraction2;
            Console.WriteLine($"Sum: {sum}");

            Fraction difference = fraction1 - fraction2;
            Console.WriteLine($"Difference: {difference}");

            Fraction product = fraction1 * fraction2;
            Console.WriteLine($"Product: {product}");

            Fraction quotient = fraction1 / fraction2;
            Console.WriteLine($"Quotient: {quotient}");

            Console.WriteLine($"Fraction1 > Fraction2: {fraction1 > fraction2}");
            Console.WriteLine($"Fraction1 == Fraction2: {fraction1 == fraction2}");

            Console.WriteLine($"Fraction1 as double: {(double)fraction1}");
        }
    }

    // Animal, Fish, Bird Classes
    class Animal
    {
        public int Age { get; set; }
        public double Weight { get; set; }
        public string Gender { get; set; }

        public Animal()
        {
        }

        public Animal(int age, double weight, string gender)
        {
            Age = age;
            Weight = weight;
            Gender = gender;
        }

        public Animal(Animal other)
        {
            Age = other.Age;
            Weight = other.Weight;
            Gender = other.Gender;
        }

        public virtual void ShowInfo()
        {
            Console.WriteLine($"Animal - Age: {Age}, Weight: {Weight}, Gender: {Gender}");
        }
    }

    class Fish : Animal
    {
        public string WaterType { get; set; }

        public Fish() : base() { }

        public Fish(int age, double weight, string gender, string waterType)
            : base(age, weight, gender)
        {
            WaterType = waterType;
        }

        public Fish(Fish other) : base(other)
        {
            WaterType = other.WaterType;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Fish - Age: {Age}, Weight: {Weight}, Gender: {Gender}, Water Type: {WaterType}");
        }
    }

    class Bird : Animal
    {
        public bool CanFly { get; set; }

        public Bird() : base() { }

        public Bird(int age, double weight, string gender, bool canFly)
            : base(age, weight, gender)
        {
            CanFly = canFly;
        }

        public Bird(Bird other) : base(other)
        {
            CanFly = other.CanFly;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Bird - Age: {Age}, Weight: {Weight}, Gender: {Gender}, Can Fly: {CanFly}");
        }
    }

    // Fraction Class
    class Fraction
    {
        public int Numerator { get; set; }
        public int Denominator { get; set; }

        public Fraction(int numerator = 0, int denominator = 1)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be zero.");
            Numerator = numerator;
            Denominator = denominator;
            Simplify();
        }

        public Fraction(Fraction other)
        {
            Numerator = other.Numerator;
            Denominator = other.Denominator;
        }

        public static Fraction operator +(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numerator * f2.Denominator + f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator);
        }

        public static Fraction operator -(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numerator * f2.Denominator - f2.Numerator * f1.Denominator, f1.Denominator * f2.Denominator);
        }

        public static Fraction operator *(Fraction f1, Fraction f2)
        {
            return new Fraction(f1.Numerator * f2.Numerator, f1.Denominator * f2.Denominator);
        }

        public static Fraction operator /(Fraction f1, Fraction f2)
        {
            if (f2.Numerator == 0)
                throw new DivideByZeroException("Cannot divide by a fraction with zero numerator.");
            return new Fraction(f1.Numerator * f2.Denominator, f1.Denominator * f2.Numerator);
        }

        public static bool operator >(Fraction f1, Fraction f2)
        {
            return f1.Numerator * f2.Denominator > f2.Numerator * f1.Denominator;
        }

        public static bool operator <(Fraction f1, Fraction f2)
        {
            return f1.Numerator * f2.Denominator < f2.Numerator * f1.Denominator;
        }

        public static bool operator >=(Fraction f1, Fraction f2)
        {
            return !(f1 < f2);
        }

        public static bool operator <=(Fraction f1, Fraction f2)
        {
            return !(f1 > f2);
        }

        public static bool operator ==(Fraction f1, Fraction f2)
        {
            return f1.Numerator * f2.Denominator == f2.Numerator * f1.Denominator;
        }

        public static bool operator !=(Fraction f1, Fraction f2)
        {
            return !(f1 == f2);
        }

        public static explicit operator double(Fraction fraction)
        {
            return (double)fraction.Numerator / fraction.Denominator;
        }

        public void Simplify()
        {
            int gcd = GCD(Numerator, Denominator);
            Numerator /= gcd;
            Denominator /= gcd;
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public override string ToString()
        {
            return $"{Numerator}/{Denominator}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Fraction other)
                return this == other;
            return false;
        }

        public override int GetHashCode()
        {
            return Numerator.GetHashCode() ^ Denominator.GetHashCode();
        }
    }
}
