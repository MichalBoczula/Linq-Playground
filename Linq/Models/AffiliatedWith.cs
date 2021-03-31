using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class AffiliatedWith
    {
        public int Physician { get; set; }
        public int Department { get; set; }
        public bool? Primaryaffiliation { get; set; }

        public virtual Department1 DepartmentNavigation { get; set; }
        public virtual Physician PhysicianNavigation { get; set; }
    }
}
