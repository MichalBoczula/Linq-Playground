using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class MatchMast
    {
        public MatchMast()
        {
            GoalDetails = new HashSet<GoalDetails>();
            PenaltyShootout = new HashSet<PenaltyShootout>();
        }

        public int MatchNo { get; set; }
        public string PlayStage { get; set; }
        public string DecidedBy { get; set; }
        public string GoalScore { get; set; }
        public DateTime? PlayDate { get; set; }
        public string Results { get; set; }
        public int? VenueId { get; set; }
        public int? RefereeId { get; set; }
        public int? Audience { get; set; }
        public int? PlrOfMatch { get; set; }
        public int? Stop1Sec { get; set; }
        public int? Stop2Sec { get; set; }

        public virtual RefereeMast Referee { get; set; }
        public virtual SoccerVenue Venue { get; set; }
        public virtual ICollection<GoalDetails> GoalDetails { get; set; }
        public virtual ICollection<PenaltyShootout> PenaltyShootout { get; set; }
    }
}
