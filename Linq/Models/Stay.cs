using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class Stay
    {
        public Stay()
        {
            Undergoes = new HashSet<Undergoes>();
        }

        public int Stayid { get; set; }
        public int? Patient { get; set; }
        public int? Room { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual Patient PatientNavigation { get; set; }
        public virtual Room RoomNavigation { get; set; }
        public virtual ICollection<Undergoes> Undergoes { get; set; }
    }
}
