using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class Room
    {
        public Room()
        {
            Stay = new HashSet<Stay>();
        }

        public int? Blockfloor { get; set; }
        public int? Blockcode { get; set; }
        public int Roomnumber { get; set; }
        public string Roomtype { get; set; }
        public bool? Unavailable { get; set; }

        public virtual Block Block { get; set; }
        public virtual ICollection<Stay> Stay { get; set; }
    }
}
