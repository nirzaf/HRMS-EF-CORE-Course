using HRMS.Dal.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Dal
{
    internal abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected DbSet<T> _dbSet;

        protected BaseRepository(HrmsDbContext hrmsDbContext)
        {
            _dbSet = hrmsDbContext.Set<T>();
        }

        public T Find(object key)
        {
            return _dbSet.Find(key);
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }
    }
}
