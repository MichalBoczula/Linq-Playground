using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class SoccerCity
    {
        public SoccerCity()
        {
            SoccerVenue = new HashSet<SoccerVenue>();
        }

        public int CityId { get; set; }
        public string City { get; set; }
        public int? CountryId { get; set; }

        public virtual SoccerCountry Country { get; set; }
        public virtual ICollection<SoccerVenue> SoccerVenue { get; set; }
    }
}
