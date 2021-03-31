using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class Movie
    {
        public int? MovId { get; set; }
        public string MovTitle { get; set; }
        public int? MovYear { get; set; }
        public int? MovTime { get; set; }
        public string MovLang { get; set; }
        public DateTime? MovDtRel { get; set; }
        public string MovRelCountry { get; set; }
    }
}
