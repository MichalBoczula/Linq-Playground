using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class MatchDetails
    {
        public int? MatchNo { get; set; }
        public int? TeamId { get; set; }
        public string PlayStage { get; set; }
        public string WinLose { get; set; }
        public string DecidedBy { get; set; }
        public int? GoalScore { get; set; }
        public int? PenaltyScore { get; set; }
        public int? AssRef { get; set; }
        public int? PlayerGk { get; set; }

        public virtual AsstRefereeMast AssRefNavigation { get; set; }
        public virtual MatchMast MatchNoNavigation { get; set; }
        public virtual SoccerTeam Team { get; set; }
    }
}
