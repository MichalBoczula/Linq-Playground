using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class RefereeMast
    {
        public RefereeMast()
        {
            MatchMast = new HashSet<MatchMast>();
        }

        public int RefereeId { get; set; }
        public string RefereeName { get; set; }
        public int? CountryId { get; set; }

        public virtual SoccerCountry Country { get; set; }
        public virtual ICollection<MatchMast> MatchMast { get; set; }
    }
}
