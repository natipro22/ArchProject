using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchProject.Repository.Common
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        ///    Save all pending changes 
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        int Commit();
    }
    public sealed class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        ///    The DbContext
        /// </summary>
        private DbContext _dbContext;
        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }
        public int Commit()
        {
            // save changes with the default options
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && _dbContext != null)
            {
                _dbContext.Dispose();
                _dbContext = null;
            }
        }
    }
}
