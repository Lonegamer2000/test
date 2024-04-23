using Microsoft.EntityFrameworkCore;
using test.Models;

namespace test.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

                
        }
        public  DbSet<Student> Students { get; set; }
    }
}
