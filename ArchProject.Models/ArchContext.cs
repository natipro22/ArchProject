using System.Data.Entity;

namespace ArchProject.Models
{
    public class ArchContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Country> Countries { get; set; }
        public ArchContext() : base("Name=DefaultConnection")
        {
            
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();  
        }

    }
}
