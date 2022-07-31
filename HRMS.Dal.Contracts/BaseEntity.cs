using System;
using System.Collections.Generic;
using System.Text;

namespace HRMS.Dal.Contracts
{
    public  abstract class BaseEntity
    {
        public string CreatedBy { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
    }
}
