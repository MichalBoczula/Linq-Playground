using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class Nurse
    {
        public Nurse()
        {
            Appointment = new HashSet<Appointment>();
            Undergoes = new HashSet<Undergoes>();
        }

        public int Employeeid { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public bool? Registered { get; set; }
        public int? Ssn { get; set; }

        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<Undergoes> Undergoes { get; set; }
    }
}
