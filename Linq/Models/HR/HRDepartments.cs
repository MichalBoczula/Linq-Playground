using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models.HR
{
    public partial class HRDepartments
    {
        public HRDepartments()
        {
            Employees1 = new HashSet<HREmployees>();
            JobHistory = new HashSet<HRJobHistory>();
        }

        public decimal DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public decimal? ManagerId { get; set; }
        public decimal? LocationId { get; set; }

        public virtual HRLocations Location { get; set; }
        public virtual ICollection<HREmployees> Employees1 { get; set; }
        public virtual ICollection<HRJobHistory> JobHistory { get; set; }
    }
}
