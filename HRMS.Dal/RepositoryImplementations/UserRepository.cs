using HRMS.Dal.Contracts.Entities;
using HRMS.Dal.Repositories;

namespace HRMS.Dal.RepositoryImplementations
{
    internal  class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(HrmsDbContext hrmsDbContext) : base(hrmsDbContext)
        {
        }
    }
}
