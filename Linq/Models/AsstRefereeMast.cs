using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class AsstRefereeMast
    {
        public int AssRefId { get; set; }
        public string AssRefName { get; set; }
        public int? CountryId { get; set; }

        public virtual SoccerCountry Country { get; set; }
    }
}
