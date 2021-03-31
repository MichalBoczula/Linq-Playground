using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class TeamCoaches
    {
        public int? TeamId { get; set; }
        public int? CoachId { get; set; }

        public virtual CoachMast Coach { get; set; }
        public virtual SoccerTeam Team { get; set; }
    }
}
