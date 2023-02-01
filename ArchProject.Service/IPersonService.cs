using ArchProject.Models;
using ArchProject.Repository;
using ArchProject.Repository.Common;
using ArchProject.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchProject.Service
{
    public interface IPersonService : IEntityService<Person>
    {
        Person GetById(long Id);
    }
    public class PersonService : EntityService<Person>, IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPersonRepository _personRepository;

        public PersonService(IUnitOfWork unitOfWork, IPersonRepository repository) 
            : base(unitOfWork, repository)
        {
            this._unitOfWork = unitOfWork;
            this._personRepository = repository;
        }
        public Person GetById(long Id)
        {
            return _personRepository.GetById(Id);
        }
    }
}
