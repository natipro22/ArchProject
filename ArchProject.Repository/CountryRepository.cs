using ArchProject.Models;
using ArchProject.Repository.Common;
using System.Data.Entity;
using System.Linq;

namespace ArchProject.Repository
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(DbContext context) : base(context)
        {

        }
        public Country GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }
    }
}
