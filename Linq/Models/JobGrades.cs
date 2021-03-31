using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Linq.Models
{
    public partial class JobGrades
    {
        public string GradeLevel { get; set; }
        public decimal? LowestSal { get; set; }
        public decimal? HighestSal { get; set; }
    }
}
