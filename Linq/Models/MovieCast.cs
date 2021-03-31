using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class MovieCast
    {
        public int? MovId { get; set; }
        public int? ActId { get; set; }
        public string Role { get; set; }
    }
}
