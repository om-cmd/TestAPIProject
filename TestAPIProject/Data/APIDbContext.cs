using Microsoft.EntityFrameworkCore;
using TestAPIProject.Models;

namespace TestAPIProject.Data
{
    public class APIDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        

        public APIDbContext(DbContextOptions options) : base(options) 
        {
        
        }
    }
}
