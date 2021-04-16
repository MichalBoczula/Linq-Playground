using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models.HR
{
    public partial class HRLocations
    {
        public HRLocations()
        {
            Departments = new HashSet<HRDepartments>();
        }

        public decimal LocationId { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string StateProvince { get; set; }
        public string CountryId { get; set; }

        public virtual HRCountries Country { get; set; }
        public virtual ICollection<HRDepartments> Departments { get; set; }
    }
}
