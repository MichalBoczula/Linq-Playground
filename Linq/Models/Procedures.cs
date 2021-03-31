using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class Procedures
    {
        public Procedures()
        {
            TrainedIn = new HashSet<TrainedIn>();
            Undergoes = new HashSet<Undergoes>();
        }

        public int Code { get; set; }
        public string Name { get; set; }
        public float? Cost { get; set; }

        public virtual ICollection<TrainedIn> TrainedIn { get; set; }
        public virtual ICollection<Undergoes> Undergoes { get; set; }
    }
}
