using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class Department1
    {
        public Department1()
        {
            AffiliatedWith = new HashSet<AffiliatedWith>();
        }

        public string Name { get; set; }
        public int Departmentid { get; set; }
        public int? Head { get; set; }

        public virtual Physician HeadNavigation { get; set; }
        public virtual ICollection<AffiliatedWith> AffiliatedWith { get; set; }
    }
}
