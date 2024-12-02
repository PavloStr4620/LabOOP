using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisciplineInfoApp
{
    enum ExamType
    {
        Exam,
        Credit,
        PassFail
    }

    class Discipline
    {
        public string Name { get; set; }
        public string TeacherFullName { get; set; }
        public string GroupName { get; set; }
        public int NumberOfStudents { get; set; }
        public ExamType ExamType { get; set; }
        public bool HasCourseWork { get; set; }
        public string SpecialtyName { get; set; }
        public int SemesterNumber { get; set; }

        public Discipline(string name, string teacherFullName, string groupName, int numberOfStudents,
                          ExamType examType, bool hasCourseWork, string specialtyName, int semesterNumber)
        {
            Name = name;
            TeacherFullName = teacherFullName;
            GroupName = groupName;
            NumberOfStudents = numberOfStudents;
            ExamType = examType;
            HasCourseWork = hasCourseWork;
            SpecialtyName = specialtyName;
            SemesterNumber = semesterNumber;
        }
    }

    

    internal class Program
    {
        static int Menu()
        {
            int menu;
            Console.WriteLine("1 - Search by last name teacher");
            Console.WriteLine("2 - Search by discipline name");
            Console.WriteLine("3 - Check the availability of coursework");
            Console.WriteLine("4 - Search by semester number");

            string input = Console.ReadLine();

            if (int.TryParse(input, out menu) && menu >= 1 && menu <= 4)
            {
                return menu;  
            }
            else
            {
                Console.WriteLine("Invalid input. Please select a number between 1 and 4.");
                return 0;  
            }
        }

        static void Main(string[] args)
        {
            Discipline[] disciplines = new Discipline[] 
            {
                new Discipline("Mathematics", "Ivanov Ivan Ivanovich", "Group A", 30, ExamType.Exam, true, "Computer Science", 1),
                new Discipline("Physics", "Petrov Petr Petrovich", "Group B", 25, ExamType.Credit, false, "Engineering", 2),
                new Discipline("Chemistry", "Sidorov Sidor Sidorovich", "Group A", 28, ExamType.PassFail, true, "Biology", 1),
                new Discipline("Programming", "Ivanov Ivan Ivanovich", "Group C", 32, ExamType.Exam, false, "Computer Science", 3)
            };

            int choice = Menu();

            if (choice == 1)
            {
                Console.WriteLine("Enter the teacher's last name:");
                string lastNameToSearch = Console.ReadLine();

                Console.WriteLine("\n");

                for (int i = 0; i < disciplines.Length; i++)
                {
                    if (disciplines[i].TeacherFullName == lastNameToSearch)
                    {
                        Console.WriteLine($"Found: {disciplines[i].Name}, Teacher: {disciplines[i].TeacherFullName}, Group: {disciplines[i].GroupName}");
                    }
                }
            }

            else if (choice == 2)
            {
                Console.WriteLine("Enter the discipline name:");
                string discipline = Console.ReadLine();

                Console.WriteLine("\n");

                for (int i = 0; i < disciplines.Length; i++)
                {
                    if (disciplines[i].Name == discipline)
                    {
                        Console.WriteLine($"Found: {disciplines[i].Name}, Teacher: {disciplines[i].TeacherFullName}, Group: {disciplines[i].GroupName}");
                    }
                }
            }

            else if (choice == 3)
            {
               
                for (int i = 0; i < disciplines.Length; i++)
                {
                    if (disciplines[i].HasCourseWork)
                    {
                        Console.WriteLine($"Found: {disciplines[i].Name}, Teacher: {disciplines[i].TeacherFullName}, Group: {disciplines[i].GroupName}");
                    }
                }
            }

            else if (choice == 4)
            {
                Console.WriteLine("Enter the semester number:");
                string temp = Console.ReadLine();
                if (int.TryParse(temp, out int number))
                {
                    Console.WriteLine("\n");

                    for (int i = 0; i < disciplines.Length; i++)
                    {
                        if (disciplines[i].SemesterNumber == number)
                        {
                            Console.WriteLine($"Found: {disciplines[i].Name}, Teacher: {disciplines[i].TeacherFullName}, Group: {disciplines[i].GroupName}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Error");
            }
            
        }
    }
}
