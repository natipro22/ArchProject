using ArchProject.Models;
using ArchProject.Repository;
using ArchProject.Repository.Common;
using ArchProject.Service.Common;

namespace ArchProject.Service
{
    public class CountryService : EntityService<Country>, ICountryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICountryRepository _countryRepository;

        public CountryService(IUnitOfWork unitOfWork, ICountryRepository repository)
            : base(unitOfWork, repository)
        {
            this._unitOfWork = unitOfWork;
            this._countryRepository = repository;
        }
        
        public Country GetById(int Id)
        {
            return _countryRepository.GetById(Id);
        }

    }
}
