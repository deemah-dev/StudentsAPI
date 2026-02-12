using Moq;
using StudentAPI.DAL;
using StudentAPI.Shared;

namespace StudentAPI.BLL.Tests
{
    public class StudentServiceTest
    {
        [Fact]
        public void GetAverageGrade_WhenCalled_ReturnsCorrectAverage()
        {
            Mock<IStudentsRepo> mockRepo = new();

            mockRepo.Setup(repo => repo.GetAverageGrade()).Returns(80.0);

            StudentService service = new(mockRepo.Object);

            var result = service.GetAverageGrade();

            Assert.Equal(80.0, result);
        }
        [Fact]
        public void FindStudent_WhenStudentIsNull_ReturnsNull()
        {
            Mock<IStudentsRepo> mockRepo = new();

            Student? student = null;
            mockRepo.Setup(repo => repo.GetStudentById(200)).Returns(student);

            StudentService service = new(mockRepo.Object);

            Student? result = service.FindStudent(200);

            Assert.Null(result);
        }
        [Fact]
        public void FindStudent_WhenStudentIsNotNull_ReturnsStudent()
        {
            Mock<IStudentsRepo> mockRepo = new();

            Student? student = new(1, "Ahmed", 18, 99);
            mockRepo.Setup(repo => repo.GetStudentById(1)).Returns(student);

            StudentService service = new(mockRepo.Object);

            Student? result = service.FindStudent(1);

            Assert.Equal(student, result);
        }
    }
}