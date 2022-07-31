using System;

namespace HRMS.Dal.Contracts.Entities
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
