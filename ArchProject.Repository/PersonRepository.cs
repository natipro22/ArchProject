using ArchProject.Models;
using ArchProject.Repository.Common;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ArchProject.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context) : base(context) { }
        public Person GetById(long id)
        {
            return _dbset.Include(p => p.Country).Where(p => p.Id == id).FirstOrDefault();
        }
        public override IEnumerable<Person> GetAll()
        {
            return _entities.Set<Person>().Include(p => p.Country).AsEnumerable();
        }

    }
}
