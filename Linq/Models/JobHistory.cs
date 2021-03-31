using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class JobHistory
    {
        public decimal EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string JobId { get; set; }
        public decimal? DepartmentId { get; set; }

        public virtual Departments Department { get; set; }
        public virtual Employees1 Employee { get; set; }
        public virtual Jobs Job { get; set; }
    }
}
