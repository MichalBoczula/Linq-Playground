using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class PlayingPosition
    {
        public PlayingPosition()
        {
            PlayerMast = new HashSet<PlayerMast>();
        }

        public string PositionId { get; set; }
        public string PositionDesc { get; set; }

        public virtual ICollection<PlayerMast> PlayerMast { get; set; }
    }
}
