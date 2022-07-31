using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HRMS.Dal
{
    internal class UnitOfWork : IUnitOfWork
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
            // do audit tracking
        }
    }
}
