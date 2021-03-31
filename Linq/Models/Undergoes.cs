using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class Undergoes
    {
        public int Patient { get; set; }
        public int Procedure { get; set; }
        public int Stay { get; set; }
        public DateTime Date { get; set; }
        public int? Physician { get; set; }
        public int? Assistingnurse { get; set; }

        public virtual Nurse AssistingnurseNavigation { get; set; }
        public virtual Patient PatientNavigation { get; set; }
        public virtual Physician PhysicianNavigation { get; set; }
        public virtual Procedures ProcedureNavigation { get; set; }
        public virtual Stay StayNavigation { get; set; }
    }
}
