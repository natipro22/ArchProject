using ArchProject.Repository.Common;
using SampleArch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchProject.Service.Common
{
    public class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<T> _repository;
        public EntityService(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }
        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            if (entity is AuditableEntity<T>)
            {
                (entity as AuditableEntity<T>).CreatedDate = DateTime.Now;
                (entity as AuditableEntity<T>).UpdatedDate = DateTime.Now;
            }
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            if (entity is AuditableEntity<T>)
            {
                (entity as AuditableEntity<T>).UpdatedDate = DateTime.Now;
            }
            _repository.Edit(entity);
            _unitOfWork.Commit();
        }
    }
}
