using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class SoccerCountry
    {
        public SoccerCountry()
        {
            AsstRefereeMast = new HashSet<AsstRefereeMast>();
            RefereeMast = new HashSet<RefereeMast>();
            SoccerCity = new HashSet<SoccerCity>();
        }

        public int CountryId { get; set; }
        public string CountryAbbr { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<AsstRefereeMast> AsstRefereeMast { get; set; }
        public virtual ICollection<RefereeMast> RefereeMast { get; set; }
        public virtual ICollection<SoccerCity> SoccerCity { get; set; }
    }
}
