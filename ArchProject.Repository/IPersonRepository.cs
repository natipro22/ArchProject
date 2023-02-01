using ArchProject.Models;
using ArchProject.Repository.Common;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ArchProject.Repository
{
    public interface IPersonRepository : IRepository<Person>
    {
        Person GetById(long id);
    }
}
