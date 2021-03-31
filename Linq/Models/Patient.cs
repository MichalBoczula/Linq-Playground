using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointment = new HashSet<Appointment>();
            Prescribes = new HashSet<Prescribes>();
            Stay = new HashSet<Stay>();
            Undergoes = new HashSet<Undergoes>();
        }

        public int Ssn { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int? Insuranceid { get; set; }
        public int? Pcp { get; set; }

        public virtual Physician PcpNavigation { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Prescribes> Prescribes { get; set; }
        public virtual ICollection<Stay> Stay { get; set; }
        public virtual ICollection<Undergoes> Undergoes { get; set; }
    }
}
