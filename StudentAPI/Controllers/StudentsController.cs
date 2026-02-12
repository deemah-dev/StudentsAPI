using Microsoft.AspNetCore.Mvc;
using StudentAPI.BLL;
using StudentAPI.Shared;

namespace StudentApI.Controllers
{
    [ApiController]
                   
    [Route("api/Students")]

    public class StudentsController : ControllerBase 
    {
        private IStudentService studentService;

        public StudentsController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet("All", Name = "GetAllStudents")] 

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<Student>> GetAllStudents()
        {
            List<Student> StudentsList = studentService.GetAllStudents();
            if (StudentsList.Count == 0)
            {
                return NotFound("No Students Found!");
            }
            return Ok(StudentsList); 

        }

        //---------------------------------------------------------------------------------------

        [HttpGet("Passed", Name = "GetPassedStudents")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<Student>> GetPassedStudents()

        {

            List<Student> PassedStudentsList = studentService.GetPassedStudents();
            if (PassedStudentsList.Count == 0)
            {
                return NotFound("No Students Found!");
            }

            return Ok(PassedStudentsList); 
        }

        //---------------------------------------------------------------------------------------


        [HttpGet("AverageGrade", Name = "GetAverageGrade")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<double> GetAverageGrade()
        {
            double averageGrade = studentService.GetAverageGrade();
            return Ok(averageGrade);
        }

        //---------------------------------------------------------------------------------------



        [HttpGet("{id}", Name = "GetStudentById")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<Student> GetStudentById(int id)
        {

            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }

            Student? SDTO = studentService.FindStudent(id);

            if (SDTO == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }


            return Ok(SDTO);

        }

        //---------------------------------------------------------------------------------------


        [HttpPost(Name = "AddStudent")]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Student> AddStudent(Student newStudent)
        {
            if (newStudent == null || string.IsNullOrEmpty(newStudent.Name) || newStudent.Age < 0 || newStudent.Grade < 0)
            {
                return BadRequest("Invalid student data.");
            }


            Student student = new Student(newStudent.Id, newStudent.Name, newStudent.Age, newStudent.Grade);
            studentService.Save(student);

            newStudent.Id = student.Id;

            return CreatedAtRoute("GetStudentById", new { id = newStudent.Id }, newStudent);

        }

        //---------------------------------------------------------------------------------------


        [HttpPut("{id}", Name = "UpdateStudent")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Student> UpdateStudent(int id, Student updatedStudent)
        {
            if (id < 1 || updatedStudent == null || string.IsNullOrEmpty(updatedStudent.Name) || updatedStudent.Age < 0 || updatedStudent.Grade < 0)
            {
                return BadRequest("Invalid student data.");
            }


            Student? student = studentService.FindStudent(id);


            if (student == null)
            {
                return NotFound($"Student with ID {id} not found.");
            }


            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            student.Grade = updatedStudent.Grade;
            studentService.Save(student);

            return Ok(student);

        }

        //---------------------------------------------------------------------------------------


        [HttpDelete("{id}", Name = "DeleteStudent")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteStudent(int id)
        {
            if (id < 1)
            {
                return BadRequest($"Not accepted ID {id}");
            }


            if (studentService.DeleteStudent(id))

                return Ok($"Student with ID {id} has been deleted.");
            else
                return NotFound($"Student with ID {id} not found. no rows deleted!");
        }

    }
}
