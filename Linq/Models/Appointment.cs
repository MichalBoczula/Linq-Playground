using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            Prescribes = new HashSet<Prescribes>();
        }

        public int Appointmentid { get; set; }
        public int? Patient { get; set; }
        public int? Prepnurse { get; set; }
        public int? Physician { get; set; }
        public DateTime? StartDtTime { get; set; }
        public DateTime? EndDtTime { get; set; }
        public string Examinationroom { get; set; }

        public virtual Patient PatientNavigation { get; set; }
        public virtual Physician PhysicianNavigation { get; set; }
        public virtual Nurse PrepnurseNavigation { get; set; }
        public virtual ICollection<Prescribes> Prescribes { get; set; }
    }
}
