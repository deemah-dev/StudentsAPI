using StudentAPI.DAL;
using StudentAPI.Shared;
using System.Xml.Linq;

namespace StudentAPI.BLL
{
    public class StudentService : IStudentService
    {
        private enMode Mode;

        public StudentService(IStudentsRepo studentsRepo)
        {
            _studentsRepo = studentsRepo;
        }
        private IStudentsRepo _studentsRepo;

        private bool _AddNewStudent(Student student)
        {
            student.Id = _studentsRepo.AddStudent(student);

            return (student.Id != -1);
        }

        private bool _UpdateStudent(Student student)
        {
            return _studentsRepo.UpdateStudent(student);
        }

        public List<Student> GetAllStudents()
        {
            return _studentsRepo.GetAllStudents();
        }

        public List<Student> GetPassedStudents()
        {
            return _studentsRepo.GetPassedStudents();
        }

        public double GetAverageGrade()
        {
            return _studentsRepo.GetAverageGrade();
        }

        public Student? FindStudent(int Id)
        {
            Student? SDTO = _studentsRepo.GetStudentById(Id);

            return SDTO;

        }

        private void SetMode(Student student)
        {
            if (student.Id == 0) Mode = enMode.AddNew;
            else Mode = enMode.Update;
        }

        public bool Save(Student student)
        {
            SetMode(student);
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewStudent(student))
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateStudent(student);

            }

            return false;
        }

        public bool DeleteStudent(int Id)
        {
            return _studentsRepo.DeleteStudent(Id);
        }
    }
}
