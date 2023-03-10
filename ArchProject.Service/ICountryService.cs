using ArchProject.Models;
using ArchProject.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchProject.Service
{
    public interface ICountryService : IEntityService<Country>
    {
        Country GetById(int Id);
    }
}
