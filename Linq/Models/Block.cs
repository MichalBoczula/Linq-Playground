using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class Block
    {
        public Block()
        {
            Room = new HashSet<Room>();
        }

        public int Blockfloor { get; set; }
        public int Blockcode { get; set; }

        public virtual ICollection<Room> Room { get; set; }
    }
}
