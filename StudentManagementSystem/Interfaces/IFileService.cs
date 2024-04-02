using StudentManagementSystem.Classes;

namespace StudentManagementSystem.Interfaces
{
  public interface IFileService
  {
    public static void LoadStudents() { }
    public static void SaveStudents(List<Student> students) { }
  }
}
