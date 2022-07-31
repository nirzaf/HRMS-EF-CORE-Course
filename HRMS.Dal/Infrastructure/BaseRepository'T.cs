using HRMS.Dal.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Dal
{
    internal abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected DbSet<T> DbSet;

        protected BaseRepository(HrmsDbContext hrmsDbContext)
        {
            DbSet = hrmsDbContext.Set<T>();
        }

        public T Find(object key)
        {
            return DbSet.Find(key);
        }

        public void Add(T entity)
        {
            DbSet.Add(entity);
        }
    }
}
