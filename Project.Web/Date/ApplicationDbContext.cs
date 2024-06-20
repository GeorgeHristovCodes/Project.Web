using Microsoft.EntityFrameworkCore;
using Project.Web.Models.Entities;

namespace Project.Web.Date
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<Person> Persons { get; set; }


    }
}
