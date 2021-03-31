using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class PlayerMast
    {
        public PlayerMast()
        {
            GoalDetails = new HashSet<GoalDetails>();
            PenaltyShootout = new HashSet<PenaltyShootout>();
        }

        public int? TeamId { get; set; }
        public int PlayerId { get; set; }
        public int? JerseyNo { get; set; }
        public string PlayerName { get; set; }
        public string PosiToPlay { get; set; }
        public DateTime? DtOfBir { get; set; }
        public int? Age { get; set; }
        public string PlayingClub { get; set; }

        public virtual PlayingPosition PosiToPlayNavigation { get; set; }
        public virtual ICollection<GoalDetails> GoalDetails { get; set; }
        public virtual ICollection<PenaltyShootout> PenaltyShootout { get; set; }
    }
}
