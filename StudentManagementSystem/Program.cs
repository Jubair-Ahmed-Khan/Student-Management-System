using StudentManagementSystem.ExtensionMethods;
using StudentManagementSystem.Classes;
using System;

namespace StudentManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****************   Welcome to Student Management System   ***************");
            Console.WriteLine();

            var students = MyExtensions.LoadStudents();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1. Add New Student");
                Console.WriteLine("2. View Student");
                Console.WriteLine("3. Delete Student");
                Console.WriteLine("4. Add Semester");
                Console.WriteLine("5. Exit (press 5 to exit)");
                int option = Convert.ToInt32(Console.ReadLine());
                int flag = 0;

                if (option != 5)
                {
                    switch (option)
                    {
                        case 1:
                            StudentManger.AddNewStudent(students);
                            break;
                        case 2:
                            StudentManger.ViewStudent(students);
                            break;
                        case 3:
                            StudentManger.DeleteStudent(students);
                            break;
                        case 4:
                            StudentManger.AddSemester(students);
                            break;
                        default:
                            flag = 1;
                            Console.WriteLine("Invalid Choices");
                            break;
                    }
                    if (flag == 0)
                        MyExtensions.SaveStudents(students);
                }
                else
                    break;

            }
        }
    }
}


