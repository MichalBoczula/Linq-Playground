using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class TrainedIn
    {
        public int Physician { get; set; }
        public int Treatment { get; set; }
        public DateTime? Certificationdate { get; set; }
        public DateTime? Certificationexpires { get; set; }

        public virtual Physician PhysicianNavigation { get; set; }
        public virtual Procedures TreatmentNavigation { get; set; }
    }
}
