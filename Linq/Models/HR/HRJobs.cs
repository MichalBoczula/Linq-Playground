using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models.HR
{
    public partial class HRJobs
    {
        public HRJobs()
        {
            Employees1 = new HashSet<HREmployees>();
            JobHistory = new HashSet<HRJobHistory>();
        }

        public string JobId { get; set; }
        public string JobTitle { get; set; }
        public decimal? MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }

        public virtual ICollection<HREmployees> Employees1 { get; set; }
        public virtual ICollection<HRJobHistory> JobHistory { get; set; }
    }
}
