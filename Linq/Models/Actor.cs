using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class Actor
    {
        public int? ActId { get; set; }
        public string ActFname { get; set; }
        public string ActLname { get; set; }
        public string ActGender { get; set; }
    }
}
