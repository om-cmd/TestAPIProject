using Microsoft.AspNetCore.Mvc;
using TestAPIProject.Data;
using TestAPIProject.Models;

namespace TestAPIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private readonly APIDbContext _db;
        public CrudController(APIDbContext db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult List()
        {
            try
            {
                var allStudents = _db.Students.ToList();
                return Ok(allStudents);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            try
            {
                var student = _db.Students.Find(id);
                return Ok(student);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Id xaina mula ");
            }

        }
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            try
            {
                var students = new Student()
                {
                    Name = student.Name,
                    Address = student.Address,
                    Age = student.Age,
                    Phone = student.Phone,
                };
                _db.Students.Add(student);
                _db.SaveChanges();
                return Ok(student);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "can't create");
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(Student student, int id)
        {
            var stud = _db.Students.FirstOrDefault(x => x.Id == id);
            if (stud == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "no student found");
            }
            try
            {
                stud.Name = student.Name;
                stud.Address = student.Address;
                stud.Age = student.Age;
                stud.Phone = student.Phone;


                _db.SaveChanges();
                return Ok(stud);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status204NoContent, "this has no body");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var stud = _db.Students.FirstOrDefault(x=>x.Id == id);
            if(stud == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "no student found");

            }
            try
            {
                _db.Remove(id);
                _db.SaveChanges();
                return Ok(stud);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status204NoContent,"kam vayena");
            }
        }

    }
}
