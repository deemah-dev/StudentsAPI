using System.Diagnostics;

namespace StudentAPI.Shared
{
    public class Student
    {
        public Student()
        {
            Id = -1;
            Name = "";
            Age = -1;
            Grade = -1;
        }
        public Student(int id, string name, int age, int grade)
        {
            Id = id;
            Name = name;
            Age = age;
            Grade = grade;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
    }
}
