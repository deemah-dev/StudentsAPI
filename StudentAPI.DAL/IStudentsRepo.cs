using StudentAPI.Shared;

namespace StudentAPI.DAL
{
    public interface IStudentsRepo
    {
        int AddStudent(Student StudentDTO);
        bool DeleteStudent(int studentId);
        List<Student> GetAllStudents();
        double GetAverageGrade();
        List<Student> GetPassedStudents();
        Student? GetStudentById(int studentId);
        bool UpdateStudent(Student StudentDTO);
    }
}