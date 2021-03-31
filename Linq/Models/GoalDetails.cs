using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class GoalDetails
    {
        public int GoalId { get; set; }
        public int? MatchNo { get; set; }
        public int? PlayerId { get; set; }
        public int? TeamId { get; set; }
        public int? GoalTime { get; set; }
        public string GoalType { get; set; }
        public string PlayStage { get; set; }
        public string GoalSchedule { get; set; }
        public int? GoalHalf { get; set; }

        public virtual MatchMast MatchNoNavigation { get; set; }
        public virtual PlayerMast Player { get; set; }
        public virtual SoccerTeam Team { get; set; }
    }
}
