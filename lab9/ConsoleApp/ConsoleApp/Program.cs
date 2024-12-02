using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp
{
    public interface ITrigonometricFigure
    {
        double GetVolume(); // Метод для обчислення об'єму фігури
    }

    public class Sphere : ITrigonometricFigure
    {
        public double Radius { get; set; }

        public Sphere(double radius)
        {
            Radius = radius;
        }

        public double GetVolume()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(Radius, 3); // Об'єм кулі
        }
    }

    public class Cube : ITrigonometricFigure
    {
        public double SideLength { get; set; }

        public Cube(double sideLength)
        {
            SideLength = sideLength;
        }

        public double GetVolume()
        {
            return Math.Pow(SideLength, 3); // Об'єм куба
        }
    }

    public class Cone : ITrigonometricFigure
    {
        public double Radius { get; set; }
        public double Height { get; set; }

        public Cone(double radius, double height)
        {
            Radius = radius;
            Height = height;
        }

        public double GetVolume()
        {
            return (1.0 / 3.0) * Math.PI * Math.Pow(Radius, 2) * Height; // Об'єм конуса
        }
    }

    public class Organization : IComparable<Organization>
    {
        public string Name { get; set; }
        public int EmployeeCount { get; set; }

        public Organization(string name, int employeeCount)
        {
            Name = name;
            EmployeeCount = employeeCount;
        }

        public int CompareTo(Organization other)
        {
            if (other == null) return 1;
            return EmployeeCount.CompareTo(other.EmployeeCount); // Порівняння за кількістю співробітників
        }
    }

    public class OrganizationComparer : IComparer<Organization>
    {
        public int Compare(Organization x, Organization y)
        {
            if (x == null || y == null)
                return 0;

            int employeeComparison = x.EmployeeCount.CompareTo(y.EmployeeCount);
            if (employeeComparison != 0)
                return employeeComparison;

            // Якщо кількість співробітників однакова, порівнюємо за рейтингом
            return GetSuccessRating(x).CompareTo(GetSuccessRating(y));
        }

        private int GetSuccessRating(Organization organization)
        {
            // Приклад рейтингу успішності
            return organization.EmployeeCount > 1000 ? 10 : (organization.EmployeeCount > 500 ? 7 : 4);
        }
    }

    public class OrganizationCollection : IEnumerable<Organization>
    {
        private List<Organization> organizations = new List<Organization>();

        public void Add(Organization organization)
        {
            organizations.Add(organization);
        }

        public IEnumerator<Organization> GetEnumerator()
        {
            return organizations.OrderBy(o => o, new OrganizationComparer()).GetEnumerator(); // Впорядкування за рейтингом
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Завдання 1
            ITrigonometricFigure sphere = new Sphere(5);
            Console.WriteLine($"Об'єм кулі: {sphere.GetVolume()}");

            ITrigonometricFigure cube = new Cube(3);
            Console.WriteLine($"Об'єм куба: {cube.GetVolume()}");

            ITrigonometricFigure cone = new Cone(3, 5);
            Console.WriteLine($"Об'єм конуса: {cone.GetVolume()}");

            // Завдання 2
            Organization org1 = new Organization("Org1", 100);
            Organization org2 = new Organization("Org2", 500);
            Organization org3 = new Organization("Org3", 1000);

            OrganizationCollection collection = new OrganizationCollection();
            collection.Add(org1);
            collection.Add(org2);
            collection.Add(org3);

            foreach (var org in collection)
            {
                Console.WriteLine($"{org.Name} - {org.EmployeeCount} співробітників");
            }
        }
    }
}
