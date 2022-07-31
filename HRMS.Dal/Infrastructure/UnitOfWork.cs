using System;
using System.Threading;
using System.Threading.Tasks;
using HRMS.Dal.Contracts;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using static System.DateTime;
using static System.GC;
using static Microsoft.EntityFrameworkCore.EntityState;

namespace HRMS.Dal
{
    internal class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly HrmsDbContext _hrmsDbContext;

        public UnitOfWork(HrmsDbContext hrmsDbContext)
        {
            _hrmsDbContext = hrmsDbContext;
        }

        public bool SaveChanges()
        {
            DoInterception();
            return _hrmsDbContext.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync(CancellationToken token = default)
        {
            DoInterception();

            return await _hrmsDbContext.SaveChangesAsync(token) > 0;
        }

        private void DoInterception()
        {
            // Convert hard delete to soft delete
            foreach (var entry in _hrmsDbContext.ChangeTracker.Entries<BaseEntity>())
            {
                if (entry.State != Deleted) continue;
                entry.State = Modified;
                entry.CurrentValues["IsDeleted"] = true;
            }
            // do audit tracking
            foreach (EntityEntry entry in _hrmsDbContext.ChangeTracker.Entries())
            {
                if (entry.State != Added && entry.State != Modified) continue;
                if (entry.Entity is not BaseEntity entity) continue;
                if (entry.State == Added)
                {
                    entity.CreatedBy = "System";
                    entity.CreatedOn = Now;
                }
                else
                {
                    entity.ModifiedBy = "System";
                    entity.ModifiedOn = Now;
                }
            }
        }
        
        public void Dispose()
        {
            _hrmsDbContext.Dispose();
            SuppressFinalize(this);
        }
    }
}
