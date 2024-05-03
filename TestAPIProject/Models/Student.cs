using System.ComponentModel.DataAnnotations;

namespace TestAPIProject.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }


    }
}
