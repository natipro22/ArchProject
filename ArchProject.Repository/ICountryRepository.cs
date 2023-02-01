using ArchProject.Models;
using ArchProject.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ArchProject.Repository
{
    public interface ICountryRepository : IRepository<Country>
    {
        Country GetById(int id);
    }
}
