using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class Medication
    {
        public Medication()
        {
            Prescribes = new HashSet<Prescribes>();
        }

        public int Code { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Prescribes> Prescribes { get; set; }
    }
}
