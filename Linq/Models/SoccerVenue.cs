using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class SoccerVenue
    {
        public SoccerVenue()
        {
            MatchMast = new HashSet<MatchMast>();
        }

        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public int? CityId { get; set; }
        public int? AudCapacity { get; set; }

        public virtual SoccerCity City { get; set; }
        public virtual ICollection<MatchMast> MatchMast { get; set; }
    }
}
