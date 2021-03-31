using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class Prescribes
    {
        public int Physician { get; set; }
        public int Patient { get; set; }
        public int Medication { get; set; }
        public DateTime Date { get; set; }
        public int? Appointment { get; set; }
        public string Dose { get; set; }

        public virtual Appointment AppointmentNavigation { get; set; }
        public virtual Medication MedicationNavigation { get; set; }
        public virtual Patient PatientNavigation { get; set; }
        public virtual Physician PhysicianNavigation { get; set; }
    }
}
