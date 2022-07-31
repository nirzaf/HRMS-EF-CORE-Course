using HRMS.Dal.Contracts.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Dal
{
    public class HrmsDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public HrmsDbContext(DbContextOptions<HrmsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(new UserRole[]
            {
                new UserRole {UserRoleId = 1, RoleName = "user"},
                new UserRole {UserRoleId = 2, RoleName = "manager"}
            });
        }
    }
}
