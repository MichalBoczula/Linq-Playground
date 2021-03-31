using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class Physician
    {
        public Physician()
        {
            AffiliatedWith = new HashSet<AffiliatedWith>();
            Appointment = new HashSet<Appointment>();
            Department1 = new HashSet<Department1>();
            Patient = new HashSet<Patient>();
            Prescribes = new HashSet<Prescribes>();
            TrainedIn = new HashSet<TrainedIn>();
            Undergoes = new HashSet<Undergoes>();
        }

        public int Employeeid { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int? Ssn { get; set; }

        public virtual ICollection<AffiliatedWith> AffiliatedWith { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Department1> Department1 { get; set; }
        public virtual ICollection<Patient> Patient { get; set; }
        public virtual ICollection<Prescribes> Prescribes { get; set; }
        public virtual ICollection<TrainedIn> TrainedIn { get; set; }
        public virtual ICollection<Undergoes> Undergoes { get; set; }
    }
}
