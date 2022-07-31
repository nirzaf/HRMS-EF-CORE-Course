using System.Threading;
using System.Threading.Tasks;

namespace HRMS.Dal
{
    public interface IUnitOfWork
    {
        bool SaveChanges();
        Task<bool> SaveChangesAsync(CancellationToken token = default);
    }
}
