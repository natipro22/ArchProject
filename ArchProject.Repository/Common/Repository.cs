using SampleArch.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ArchProject.Repository.Common
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected DbContext _entities;
        protected readonly IDbSet<T> _dbset;
        public Repository(DbContext context)
        {
            _entities = context;
            _dbset = context.Set<T>(); ;
        }
        public virtual T Add(T entity)
        {
            return _dbset.Add(entity);
        }

        public virtual T Delete(T entity)
        {
            return _dbset.Remove(entity);
        }

        public virtual void Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate).AsEnumerable();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbset.AsEnumerable<T>();
        }

        public void Save()
        {
            _entities.SaveChanges();
        }
    }
}
