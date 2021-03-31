using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class Departments
    {
        public Departments()
        {
            Employees1 = new HashSet<Employees1>();
            JobHistory = new HashSet<JobHistory>();
        }

        public decimal DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public decimal? ManagerId { get; set; }
        public decimal? LocationId { get; set; }

        public virtual Locations Location { get; set; }
        public virtual ICollection<Employees1> Employees1 { get; set; }
        public virtual ICollection<JobHistory> JobHistory { get; set; }
    }
}
