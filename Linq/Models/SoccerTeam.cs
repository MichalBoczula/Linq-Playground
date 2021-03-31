using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class SoccerTeam
    {
        public SoccerTeam()
        {
            GoalDetails = new HashSet<GoalDetails>();
            PenaltyShootout = new HashSet<PenaltyShootout>();
        }

        public int TeamId { get; set; }
        public string TeamGroup { get; set; }
        public int? MatchPlayed { get; set; }
        public int? Won { get; set; }
        public int? Draw { get; set; }
        public int? Lost { get; set; }
        public int? GoalFor { get; set; }
        public int? GoalAgnst { get; set; }
        public int? GoalDiff { get; set; }
        public int? Points { get; set; }
        public int? GroupPosition { get; set; }

        public virtual ICollection<GoalDetails> GoalDetails { get; set; }
        public virtual ICollection<PenaltyShootout> PenaltyShootout { get; set; }
    }
}
