using SampleArch.Model;
using System.Collections.Generic;

namespace ArchProject.Service.Common
{
    public interface IEntityService<T> : IService where T : BaseEntity
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
    
}
