using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class Employees
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string JobName { get; set; }
        public int? ManagerId { get; set; }
        public DateTime? HireDate { get; set; }
        public decimal? Salary { get; set; }
        public decimal? Commission { get; set; }
        public int? DepId { get; set; }

        public virtual Department Dep { get; set; }
    }
}
