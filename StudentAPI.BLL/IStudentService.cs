using StudentAPI.Shared;

namespace StudentAPI.BLL
{
    public interface IStudentService
    {
        bool DeleteStudent(int ID);
        Student? FindStudent(int ID);
        List<Student> GetAllStudents();
        double GetAverageGrade();
        List<Student> GetPassedStudents();
        bool Save(Student student);
    }
}