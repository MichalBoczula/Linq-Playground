using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class Countries
    {
        public Countries()
        {
            Locations = new HashSet<Locations>();
        }

        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public decimal? RegionId { get; set; }

        public virtual Regions Region { get; set; }
        public virtual ICollection<Locations> Locations { get; set; }
    }
}
