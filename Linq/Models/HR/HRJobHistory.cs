using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models.HR
{
    public partial class HRJobHistory
    {
        public decimal EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string JobId { get; set; }
        public decimal? DepartmentId { get; set; }

        public virtual HRDepartments Department { get; set; }
        public virtual HREmployees Employee { get; set; }
        public virtual HRJobs Job { get; set; }
    }
}
