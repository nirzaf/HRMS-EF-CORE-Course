using HRMS.Dal.Contracts;

namespace HRMS.Dal
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Find(object key);
        void Add(T entity);
    }
}