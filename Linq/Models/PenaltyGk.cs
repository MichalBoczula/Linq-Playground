using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class PenaltyGk
    {
        public int? MatchNo { get; set; }
        public int? TeamId { get; set; }
        public int? PlayerGk { get; set; }

        public virtual MatchMast MatchNoNavigation { get; set; }
        public virtual SoccerTeam Team { get; set; }
    }
}
