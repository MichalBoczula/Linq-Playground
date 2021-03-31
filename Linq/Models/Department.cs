using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employees>();
        }

        public int DepId { get; set; }
        public string DepName { get; set; }
        public string DepLocation { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
