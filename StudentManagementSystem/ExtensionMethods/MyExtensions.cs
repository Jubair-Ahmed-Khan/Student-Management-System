using StudentManagementSystem.Classes;
using Newtonsoft.Json;
using StudentManagementSystem.Interfaces;
namespace StudentManagementSystem.ExtensionMethods
{

  public class MyExtensions : IFileService
  {
    private static readonly string StudentsFilePath = "students.json";
    public static List<Student>? LoadStudents()
    {
      if (File.Exists(StudentsFilePath))
      {
        string json = File.ReadAllText(StudentsFilePath);
        return JsonConvert.DeserializeObject<List<Student>>(json) ?? [];
      }
      return [];
    }
    public static void SaveStudents(List<Student> students)
    {
      string json = JsonConvert.SerializeObject(students, Formatting.Indented);
      File.WriteAllText(StudentsFilePath, json);
    }
  }
}