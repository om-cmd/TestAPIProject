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

            var allStudents = _db.Students.Where(x=>!x.IsActive).ToList();
            return Ok(allStudents);

        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = _db.Students.Find(id);
            return Ok(student);

        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            var existingStudent = _db.Students.FirstOrDefault(x => x.Id == id);
            if (existingStudent == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Student with id {id} not found.");
            }

            existingStudent.Name = student.Name;
            existingStudent.Address = student.Address;
            existingStudent.Age = student.Age;
            existingStudent.Phone = student.Phone;

            _db.SaveChanges();
            return Ok(existingStudent);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var existingStudent = _db.Students.FirstOrDefault(x => x.Id == id);
            if (existingStudent == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, $"Student with id {id} not found.");
            }

            existingStudent.IsActive = true;
            //_db.Students.Remove(existingStudent);
            _db.SaveChanges();
            return Ok(existingStudent);

        }
    }
}
