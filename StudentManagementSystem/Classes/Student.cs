using StudentManagementSystem.Enums;

namespace StudentManagementSystem.Classes
{
  public class Student
  {
    public Student()
    {
      SemestersAttended = [];
      AttendedCourse = [];
      JoiningBatch = string.Empty;
    }

    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = string.Empty;
    public string StudentId { get; set; } = string.Empty;
    public string? JoiningBatch { get; set; }
    public Department Department { get; set; } = Department.None;
    public Degree Degree { get; set; } = Degree.None;
    public List<Course> AttendedCourse { get; set; }
    public List<Semester> SemestersAttended { get; set; }
  }
}
