using System.Data;
using StudentManagementSystem.Enums;
using StudentManagementSystem.Interfaces;
// using Newtonsoft.Json;
namespace StudentManagementSystem.Classes
{
  public class StudentManger : IStudentService
  {
    // private static readonly string StudentsFilePath = "students.json";
    public static readonly List<Course> allCourses = [
        new Course { CourseId = "CSE 101", CourseName = "C Programming", InstructorName = "Prof. Nasir", NumberOfCredits = 3.5},
        new Course { CourseId = "CSE 102", CourseName = "Machine Learning", InstructorName = "Prof. Motiur", NumberOfCredits = 2.5},
        new Course { CourseId = "CSE 103", CourseName = "Java Programming", InstructorName = "Prof. Nasir", NumberOfCredits = 3.5},
        new Course { CourseId = "CSE 104", CourseName = "Arcitecture", InstructorName = "Prof. Motiur", NumberOfCredits = 2.5}
        ];
    public static void AddNewStudent(List<Student> students)
    {

      try
      {

        Console.Write("First Name : ");
        dynamic? firstName = Console.ReadLine();

        Console.Write("Middle Name : ");
        dynamic? middleName = Console.ReadLine();

        Console.Write("Last Name : ");
        dynamic? lastName = Console.ReadLine();

        Console.Write("Student ID (format XXX-XXX-XXX) : ");
        dynamic? studentID = Console.ReadLine();

        Console.Write("Department Number (1 for CSE , 2 for BBA, 3 for English) : ");
        dynamic? department = Convert.ToInt32(Console.ReadLine());

        Console.Write("Degree Number : ");
        dynamic? degree = Convert.ToInt32(Console.ReadLine());

        Student newStudent = new()
        {
          FirstName = firstName,
          MiddleName = middleName,
          LastName = lastName,
          StudentId = studentID,
          Department = (Department)Enum.Parse(typeof(Department), department.ToString()),
          Degree = (Degree)Enum.Parse(typeof(Degree), degree.ToString()),
          JoiningBatch = "Winter",
        };
        students.Add(newStudent);

        Console.WriteLine("Student Added Successfully");
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }


    }

    public static void ViewStudent(List<Student> students)
    {
      try
      {
        Console.Write("Enter Student ID: ");
        string? studentId = Console.ReadLine();

        Student? student = students.Find(s => s.StudentId == studentId);

        if (student != null)
        {
          Console.WriteLine("Student Details:");
          Console.WriteLine($"Name: {student.FirstName} {student.MiddleName} {student.LastName}");
          Console.WriteLine($"Student ID: {student.StudentId}");
          Console.WriteLine($"Joining Batch: {student.JoiningBatch}");
          Console.WriteLine($"Department: {student.Department}");
          Console.WriteLine($"Degree: {student.Degree}");
          Console.WriteLine("Attended Courses Are : ");
          foreach (var semester in student.SemestersAttended)
          {
            Console.WriteLine($"Semester: {semester.SemesterCode} {semester.Year}");
            foreach (var course in student.AttendedCourse)
            {
              Console.WriteLine($"Course ID: {course.CourseId}, Course Name: {course.CourseName}, Instructor: {course.InstructorName}, Credits: {course.NumberOfCredits}");
            }
          }
        }
        else
        {
          Console.WriteLine($"Student with ID {studentId} not found.");
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }
    }

    public static void DeleteStudent(List<Student> students)
    {

      try
      {
        Console.Write("Enter Student ID to delete: ");
        string? studentIDToDelete = Console.ReadLine();

        Student? studentToDelete = students.Find(s => s.StudentId == studentIDToDelete);

        if (studentToDelete != null)
        {
          students.Remove(studentToDelete);
          Console.WriteLine($"Student with ID {studentIDToDelete} deleted successfully.");
        }
        else
        {
          Console.WriteLine($"Student with ID {studentIDToDelete} not found.");
        }
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }

    }

    public static void AddSemester(List<Student> students)
    {

      try
      {
        Console.Write("Enter Student ID: ");

        string? studentId = Console.ReadLine();
        Student? studentToFind = students.Find(s => s.StudentId == studentId);

        if (studentToFind != null)
        {
          Console.Write("Enter Semester Code (1: Summer, 2: Fall, 3: Spring): ");
          int semCode = Convert.ToInt32(Console.ReadLine());
          var semesterCode = (SemesterCode)Enum.Parse(typeof(SemesterCode), semCode.ToString());

          Console.Write("Enter Year (YYYY): ");
          string? year = Console.ReadLine();

          bool isSemesterAttended = studentToFind.SemestersAttended.Any(semester =>
          semester.SemesterCode == semesterCode && semester.Year == year);

          if (isSemesterAttended)
          {
            Console.WriteLine("Already attened the course");
          }
          else
          {
            studentToFind.SemestersAttended.Add(new Semester { SemesterCode = semesterCode, Year = year });
            Console.WriteLine("Available Courses: ");
            var availableCourses = allCourses.Where(c => !studentToFind.AttendedCourse.Any(x => x.CourseId == c.CourseId)).ToList();
            foreach (var course in availableCourses)
            {
              Console.WriteLine($"{course.CourseName}");
            }

            Console.WriteLine("How many courses do you want to take? : ");
            int num = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
              Console.Write("Enter Course ID to add (XXX YYY): ");
              string? selectedCourseID = Console.ReadLine();

              var course = availableCourses.Find(x => x.CourseId == selectedCourseID);
              if (course != null)
              {
                studentToFind.AttendedCourse.Add(course);
                course = null;
              }
              else
              {
                Console.WriteLine("course is not available");
              }
            }
          }
        }
        else
        {
          Console.WriteLine("Student not found.");
        }

      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
      }

    }
  }
}
