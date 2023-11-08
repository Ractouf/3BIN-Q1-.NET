using Microsoft.AspNetCore.Mvc;
using semaine5_2.Models;

namespace semaine5_2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> _students = new List<Student>()
        {
        new Student { Id = 1, FirstName = "Esteban", LastName = "Ocon", Birthdate = new DateTime(1996, 9, 17) },
        new Student { Id = 2, FirstName = "Pierre", LastName = "Gasly", Birthdate = new DateTime(1996, 2, 7) },
        new Student { Id = 3, FirstName = "Fernando", LastName = "Alonso", Birthdate = new DateTime(1981, 7, 29) }
        };

        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "students")]
        public IEnumerable<Student> Get()
        {
            return _students;
        }

        [HttpPost(Name = "students")]
        public IEnumerable<Student> Add(Student student)
        {
            _students.Add(student);
            return _students;
        }
    }
}