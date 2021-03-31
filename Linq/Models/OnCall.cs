using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class OnCall
    {
        public int Nurse { get; set; }
        public int Blockfloor { get; set; }
        public int Blockcode { get; set; }
        public DateTime Oncallstart { get; set; }
        public DateTime Oncallend { get; set; }

        public virtual Block Block { get; set; }
        public virtual Nurse NurseNavigation { get; set; }
    }
}
